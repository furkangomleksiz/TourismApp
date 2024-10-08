using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class Tour
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string GeneralInfo { get; set; } // HTML strings
        public string SlugUrl { get; set; } // Slug URL
        public string Image { get; set; } // Image URL
        public int DayNum { get; set; }
        public int NightNum { get; set; }
        public List<TourImage> Gallery { get; set; } = new List<TourImage>(); // 1 to many relation
        public bool IsActive { get; set; }
        public List<TourProduct> TourProducts { get; set; } = new List<TourProduct>();
        public DateTime? DeletedAt { get; set; }
    }
}