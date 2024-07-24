using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class SoftDeleteOrderCommandHandler : IRequestHandler<SoftDeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public SoftDeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(SoftDeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.SoftDeleteOrderAsync(request.OrderId);
        }
    }

}