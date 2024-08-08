using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class UpdateTourProductPriceCommandHandler : IRequestHandler<UpdateTourProductPriceCommand>
    {
        private readonly ITourProductPriceRepository _tourProductPriceRepository;

        public UpdateTourProductPriceCommandHandler(ITourProductPriceRepository tourProductPriceRepository)
        {
            _tourProductPriceRepository = tourProductPriceRepository;
        }

        public async Task Handle(UpdateTourProductPriceCommand request, CancellationToken cancellationToken)
        {
            var tourProductPrice = await _tourProductPriceRepository.GetByIdAsync(request.Id);

            if (tourProductPrice == null)
            {
                throw new InvalidOperationException("Tour product price not found.");
            }

            tourProductPrice.Price = request.Price;
            await _tourProductPriceRepository.UpdateAsync(tourProductPrice);
        }
    }
}