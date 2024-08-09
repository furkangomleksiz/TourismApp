using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class OrderTourProductPrice
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid TourProductPriceId { get; set; }

        public Order Order { get; set; }
        public TourProductPrice TourProductPrice { get; set; }

        // Snapshot properties
        public PriceType PriceType { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderPayment> OrderPayments { get; set; }
    }
}