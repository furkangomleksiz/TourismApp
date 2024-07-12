using MediatR;
using System;
using System.Collections.Generic;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Queries
{
    public class GetAllTourProductsQuery : IRequest<List<TourProduct>>
    {
    }
}