using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
            {
                return null;
            }

            return new OrderDTO
            {
                Id = order.Id,
                TourProductId = order.TourProductId,
                MainPaxId = order.MainPaxId,
                Status = order.Status,
                PaxIds = order.Paxes.Select(pax => pax.Id).ToList()
            };
        }
    }
}