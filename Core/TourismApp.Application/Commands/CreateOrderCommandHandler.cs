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
        private readonly ITourProductRepository _tourProductRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IPaxRepository paxRepository, ITourProductRepository tourProductRepository)
        {
            _orderRepository = orderRepository;
            _paxRepository = paxRepository;
            _tourProductRepository = tourProductRepository;
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

            return new OrderDTO
            {
                Id = order.Id,
                TourProductId = order.TourProductId,
                Status = order.Status,
                MainPaxId = order.MainPaxId,
                PaxIds = request.PaxIds
            };
        }
    }

}