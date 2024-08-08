using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Queries
{
    public class GetTourProductPriceByIdQuery : IRequest<TourProductPrice>
    {
        public Guid Id { get; set; }

        public GetTourProductPriceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}