using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class TourProduct
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }  // Foreign key to Tour entity
        public DateTime SalesStartDate { get; set; }
        public DateTime SalesEndDate { get; set; }
        public DateTime TourStartDate { get; set; }
        public DateTime TourEndDate { get; set; }
        public decimal Price { get; set; }

        // Navigation property to Tour entity
        public Tour Tour { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<Order> Orders { get; set; }
        public ICollection<TourProductPrice> TourProductPrices { get; set; }
        public ICollection<OrderTourProduct> OrderTourProducts { get; set; }

    }
}