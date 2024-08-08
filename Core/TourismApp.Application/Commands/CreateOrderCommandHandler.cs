using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaxRepository _paxRepository;
        private readonly ITourRepository _tourRepository;
        private readonly ITourProductRepository _tourProductRepository;
        private readonly ITourProductPriceRepository _tourProductPriceRepository;
        private readonly IOrderTourRepository _orderTourRepository;
        private readonly IOrderTourProductRepository _orderTourProductRepository;
        private readonly IOrderTourProductPriceRepository _orderTourProductPriceRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IPaxRepository paxRepository,
            ITourRepository tourRepository,
            ITourProductRepository tourProductRepository,
            ITourProductPriceRepository tourProductPriceRepository,
            IOrderTourRepository orderTourRepository,
            IOrderTourProductRepository orderTourProductRepository,
            IOrderTourProductPriceRepository orderTourProductPriceRepository
            )
        {
            _orderRepository = orderRepository;
            _paxRepository = paxRepository;
            _tourRepository = tourRepository;
            _tourProductRepository = tourProductRepository;
            _tourProductPriceRepository = tourProductPriceRepository;
            _orderTourRepository = orderTourRepository;
            _orderTourProductRepository = orderTourProductRepository;
            _orderTourProductPriceRepository = orderTourProductPriceRepository;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var tourProduct = await _tourProductRepository.GetByIdAsync(request.TourProductId);

            if (request.PaxIds == null || request.PaxIds.Count == 0)
                throw new ArgumentException("At least one pax ID must be provided.");

            if (tourProduct == null)
            {
                throw new Exception("TourProduct not found");
            }
            var mainPax = await _paxRepository.GetByIdAsync(request.PaxIds.First());

            if (mainPax == null)
                throw new Exception("Main Pax not found");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TourProductId = request.TourProductId,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Taken,
                MainPaxId = mainPax.Id,
                Paxes = new List<Pax>()
            };

            foreach (var paxId in request.PaxIds)
            {
                var pax = await _paxRepository.GetByIdAsync(paxId);
                if (pax != null)
                {
                    pax.OrderId = order.Id;
                    pax.Order = order;
                    order.Paxes.Add(pax);
                }
            }

            await _orderRepository.AddOrderAsync(order);

            var tour = await _tourRepository.GetTourByIdAsync(tourProduct.TourId);

            var orderTour = new OrderTour
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                TourId = tourProduct.TourId,
                Title = tour.Title,
                Description = tour.GeneralInfo,
                DayNum = tour.DayNum,
                NightNum = tour.NightNum,
            };
            await _orderTourRepository.CreateAsync(orderTour);

            var paxes = new List<Pax>();
            foreach (var paxId in request.PaxIds)
            {
                var pax = await _paxRepository.GetByIdAsync(paxId);
                if (pax != null)
                {
                    paxes.Add(pax);
                }
            }

            var orderTourProduct = new OrderTourProduct
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                TourProductId = tourProduct.Id,
                StartDate = tourProduct.TourStartDate,
                EndDate = tourProduct.TourEndDate,
                BasePrice = tourProduct.Price
            };

            await _orderTourProductRepository.CreateAsync(orderTourProduct);

            var tourProductPrice = await DetermineTourProductPriceAsync(paxes, request.TourProductId);

            var orderTourProductPrice = new OrderTourProductPrice
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                TourProductPriceId = tourProductPrice.Id,
                PriceType = tourProductPrice.PriceType,
                Price = tourProductPrice.Price
            };
            await _orderTourProductPriceRepository.CreateAsync(orderTourProductPrice);


            return new OrderDTO
            {
                Id = order.Id,
                TourProductId = order.TourProductId,
                Status = order.Status,
                MainPaxId = order.MainPaxId,
                PaxIds = request.PaxIds
            };
        }

        private async Task<TourProductPrice> DetermineTourProductPriceAsync(List<Pax> paxes, Guid tourProductId)
        {
            // Ensure there are no more than two child paxes
            var childPaxes = paxes.Where(p => IsChild(p.DateOfBirth)).ToList();
            if (childPaxes.Count > 1)
            {
                throw new InvalidOperationException("Only one child pax is allowed.");
            }

            // Determine price type based on pax count and types
            var priceType = DeterminePriceType(paxes);

            // Fetch the corresponding TourProductPrice from the repository
            var tourProductPrices = await _tourProductPriceRepository.GetAllAsync();
            var selectedPrice = await _tourProductPriceRepository.GetByTypeAsync(tourProductId, priceType);

            if (selectedPrice == null)
            {
                throw new InvalidOperationException("No TourProductPrice found for the specified price type.");
            }

            return selectedPrice;
        }

        private PriceType DeterminePriceType(List<Pax> paxes)
        {
            var adultPaxes = paxes.Where(p => !IsChild(p.DateOfBirth)).ToList();
            var childPaxes = paxes.Where(p => IsChild(p.DateOfBirth)).ToList();

            if (adultPaxes.Count == 1 && childPaxes.Count == 1)
            {
                return PriceType.SINGLEWITHCHILD;
            }
            else if (adultPaxes.Count == 2 && childPaxes.Count == 1)
            {
                return PriceType.DOUBLEWITHCHILD;
            }
            else if (adultPaxes.Count == 1)
            {
                return PriceType.SINGLE;
            }
            else if (adultPaxes.Count == 2)
            {
                return PriceType.DOUBLE;
            }
            else if (adultPaxes.Count == 3)
            {
                return PriceType.TRIPLE;
            }
            else
            {
                throw new InvalidOperationException("Unsupported pax combination.");
            }
        }

        private bool IsChild(DateTime? dateOfBirth)
        {
            if (dateOfBirth == null) return false;

            var age = DateTime.UtcNow.Year - dateOfBirth.Value.Year;
            if (DateTime.UtcNow.Date < dateOfBirth.Value.Date.AddYears(age)) age--;

            return age >= 12 && age < 18;
        }

    }

}