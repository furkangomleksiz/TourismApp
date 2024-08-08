using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class TourProductPrice
    {
        public Guid Id { get; set; }
        public Guid TourProductId { get; set; }
        public TourProduct TourProduct { get; set; }
        public PriceType PriceType { get; set; }
        public decimal Price { get; set; }
    }

    public enum PriceType
    {
        SINGLE,
        DOUBLE,
        TRIPLE,
        SINGLEWITHCHILD,
        DOUBLEWITHCHILD
    }

}