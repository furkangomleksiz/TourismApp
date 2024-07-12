using MediatR;
using System;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Queries
{
    public class GetTourProductDetailsQuery : IRequest<TourProduct>
    {
        public Guid Id { get; }

        public GetTourProductDetailsQuery(Guid id)
        {
            Id = id;
        }
    }
}
