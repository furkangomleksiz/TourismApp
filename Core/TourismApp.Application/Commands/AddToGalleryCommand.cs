using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TourismApp.Application.Commands
{
    public class AddToGalleryCommand : IRequest<bool>
    {
        public Guid TourId { get; set; }
        public string ImageUrl { get; set; }
    }
}