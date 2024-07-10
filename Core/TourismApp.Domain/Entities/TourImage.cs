using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class TourImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } // Image URL
        public Guid TourId { get; set; } // Foreign key to Tour
        public Tour Tour { get; set; } // Navigation property
    }
}