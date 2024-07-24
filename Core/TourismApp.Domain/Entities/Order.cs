using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public enum OrderStatus
    {
        Taken,
        Paid,
        Cancelled
    }

    public class Order
    {
        public Guid Id { get; set; }
        public Guid TourProductId { get; set; }
        public TourProduct TourProduct { get; set; }
        public Guid MainPaxId { get; set; }
        public List<Pax> Paxes { get; set; } = new List<Pax>();
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}