using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Commands
{
    public class CreatePaxCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}