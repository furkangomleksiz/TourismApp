using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid TourProductId { get; set; }
        public Guid MainPaxId { get; set; }
        public OrderStatus Status { get; set; }
        public List<Guid> PaxIds { get; set; }
    }
}