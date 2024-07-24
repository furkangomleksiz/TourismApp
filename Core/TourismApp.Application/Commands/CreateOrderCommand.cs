using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public Guid TourProductId { get; set; }
        public List<Guid> PaxIds { get; set; }
    }
}