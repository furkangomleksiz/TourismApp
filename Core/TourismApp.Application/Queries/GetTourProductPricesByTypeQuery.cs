using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Queries
{
    public class GetTourProductPricesByTypeQuery : IRequest<TourProductPrice>
    {
        public Guid TourProductId { get; set; }
        public PriceType PriceType { get; set; }

        public GetTourProductPricesByTypeQuery(Guid tourProductId, PriceType priceType)
        {
            TourProductId = tourProductId;
            PriceType = priceType;
        }
    }

}