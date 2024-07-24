using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;

namespace TourismApp.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
{
    public Guid OrderId { get; set; }

    public GetOrderByIdQuery(Guid orderId)
    {
        OrderId = orderId;
    }
}
}