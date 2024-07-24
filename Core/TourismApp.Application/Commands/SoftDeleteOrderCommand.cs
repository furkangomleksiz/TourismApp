using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TourismApp.Application.Commands
{
    public class SoftDeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public SoftDeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}