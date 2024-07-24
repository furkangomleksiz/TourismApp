using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;

namespace TourismApp.Application.Queries
{
    public class GetOrdersByTourProductIdQuery : IRequest<List<OrderDTO>>
{
    public Guid TourProductId { get; set; }

    public GetOrdersByTourProductIdQuery(Guid tourProductId)
    {
        TourProductId = tourProductId;
    }
}
}