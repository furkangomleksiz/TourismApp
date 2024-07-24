using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class CreatePaxCommandHandler : IRequestHandler<CreatePaxCommand, Guid>
    {
        private readonly IPaxRepository _paxRepository;

        public CreatePaxCommandHandler(IPaxRepository paxRepository)
        {
            _paxRepository = paxRepository;
        }

        public async Task<Guid> Handle(CreatePaxCommand request, CancellationToken cancellationToken)
        {
            var pax = new Pax
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                TCKN = request.TCKN,
                PhoneNumber = request.PhoneNumber
            };

            await _paxRepository.AddAsync(pax);

            return pax.Id;
        }
    }
}