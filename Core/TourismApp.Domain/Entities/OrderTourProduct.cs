using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class OrderTourProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid TourProductId { get; set; }

        public Order Order { get; set; }
        public TourProduct TourProduct { get; set; }

        // Snapshot properties
        public decimal BasePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}