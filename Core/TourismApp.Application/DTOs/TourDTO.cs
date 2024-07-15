using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Application.DTOs
{
    public class TourDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<TourProductDto> TourProducts { get; set; } = new List<TourProductDto>();
    }
}