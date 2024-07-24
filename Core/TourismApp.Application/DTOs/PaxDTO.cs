using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Application.DTOs
{
    public class PaxDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKN { get; set; }
        public string PhoneNumber { get; set; }
    }
}