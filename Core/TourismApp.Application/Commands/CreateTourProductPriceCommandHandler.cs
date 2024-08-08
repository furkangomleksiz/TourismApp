using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class CreateTourProductPriceCommandHandler : IRequestHandler<CreateTourProductPriceCommand, Guid>
    {
        private readonly ITourProductPriceRepository _tourProductPriceRepository;

        public CreateTourProductPriceCommandHandler(ITourProductPriceRepository tourProductPriceRepository)
        {
            _tourProductPriceRepository = tourProductPriceRepository;
        }

        public async Task<Guid> Handle(CreateTourProductPriceCommand request, CancellationToken cancellationToken)
        {
            var tourProductPrice = new TourProductPrice
            {
                Id = Guid.NewGuid(), // Generate a new Guid for the entity
                TourProductId = request.TourProductId,
                PriceType = request.PriceType,
                Price = request.Price
            };

            return await _tourProductPriceRepository.CreateAsync(tourProductPrice);
        }
    }

}