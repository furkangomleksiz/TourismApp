using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Queries
{
    public class GetOrdersByTourProductIdQueryHandler : IRequestHandler<GetOrdersByTourProductIdQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByTourProductIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersByTourProductIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByTourProductIdAsync(request.TourProductId);

            var orderDtos = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                TourProductId = order.TourProductId,
                MainPaxId = order.MainPaxId,
                Status = order.Status,
                PaxIds = order.Paxes.Select(pax => pax.Id).ToList()
            }).ToList();

            return orderDtos;
        }
    }
}