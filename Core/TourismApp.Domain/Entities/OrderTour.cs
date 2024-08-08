using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class OrderTour
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid TourId { get; set; }
        public Order Order { get; set; }
        public Tour Tour { get; set; }

        // Snapshot properties
        public string Title { get; set; }
        public string Description { get; set; }
        public int DayNum { get; set; }
        public int NightNum { get; set; }
    }
}