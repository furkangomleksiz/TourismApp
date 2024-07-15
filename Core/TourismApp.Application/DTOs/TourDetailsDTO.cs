using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.DTOs
{
    public class TourDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string GeneralInfo { get; set; }
        public string SlugUrl { get; set; }
        public string Image { get; set; }
        public int DayNum { get; set; }
        public int NightNum { get; set; }
        public List<TourImage> GalleryImages { get; set; } = new List<TourImage>();
        public bool IsActive { get; set; }
        public List<TourProductDto> TourProducts { get; set; } = new List<TourProductDto>();
    }
}