using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Queries
{
    public class GetTourProductPricesByTypeQueryHandler : IRequestHandler<GetTourProductPricesByTypeQuery, TourProductPrice>
    {
        private readonly ITourProductPriceRepository _tourProductPriceRepository;

        public GetTourProductPricesByTypeQueryHandler(ITourProductPriceRepository tourProductPriceRepository)
        {
            _tourProductPriceRepository = tourProductPriceRepository;
        }

        public async Task<TourProductPrice> Handle(GetTourProductPricesByTypeQuery request, CancellationToken cancellationToken)
        {
            var tourProductPrice = await _tourProductPriceRepository.GetByTypeAsync(request.TourProductId, request.PriceType);
            if (tourProductPrice == null)
            {
                throw new KeyNotFoundException($"TourProductPrice with TourProductId {request.TourProductId} and PriceType {request.PriceType} not found.");
            }

            return tourProductPrice;
        }
    }

}