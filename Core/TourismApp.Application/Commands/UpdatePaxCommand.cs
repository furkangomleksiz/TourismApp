using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TourismApp.Application.Commands
{
    public class UpdatePaxCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UpdatePaxCommand(Guid id, string name, string surname, string tckn, string phoneNumber, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            TCKN = tckn;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }
    }

}