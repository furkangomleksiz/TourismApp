using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System;

namespace TourismApp.Application.Commands
{
    public class CreateTourProductCommand : IRequest<Guid>
    {
        public Guid TourId { get; set; }
        public DateTime SalesStartDate { get; set; }
        public DateTime SalesEndDate { get; set; }
        public DateTime TourStartDate { get; set; }
        public DateTime TourEndDate { get; set; }
    }
}