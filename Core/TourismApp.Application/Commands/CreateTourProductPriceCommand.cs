using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Commands
{
    public class CreateTourProductPriceCommand : IRequest<Guid>
    {
        public Guid TourProductId { get; set; }
        public PriceType PriceType { get; set; }
        public decimal Price { get; set; }
    }
}