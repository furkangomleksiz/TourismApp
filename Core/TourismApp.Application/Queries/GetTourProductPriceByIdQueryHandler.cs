using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Queries
{
    public class GetTourProductPriceByIdQueryHandler : IRequestHandler<GetTourProductPriceByIdQuery, TourProductPrice>
    {
        private readonly ITourProductPriceRepository _tourProductPriceRepository;

        public GetTourProductPriceByIdQueryHandler(ITourProductPriceRepository tourProductPriceRepository)
        {
            _tourProductPriceRepository = tourProductPriceRepository;
        }

        public async Task<TourProductPrice> Handle(GetTourProductPriceByIdQuery request, CancellationToken cancellationToken)
        {
            var tourProductPrice = await _tourProductPriceRepository.GetByIdAsync(request.Id);
            if (tourProductPrice == null)
            {
                throw new KeyNotFoundException($"TourProductPrice with Id {request.Id} not found.");
            }
            return tourProductPrice;
        }
    }

}