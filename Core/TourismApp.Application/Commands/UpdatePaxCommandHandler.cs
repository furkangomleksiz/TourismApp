using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class UpdatePaxCommandHandler : IRequestHandler<UpdatePaxCommand, bool>
    {
        private readonly IPaxRepository _paxRepository;

        public UpdatePaxCommandHandler(IPaxRepository paxRepository)
        {
            _paxRepository = paxRepository;
        }

        public async Task<bool> Handle(UpdatePaxCommand request, CancellationToken cancellationToken)
        {
            var pax = await _paxRepository.GetByIdAsync(request.Id);

            if (pax == null)
            {
                return false;
            }

            pax.Name = request.Name;
            pax.Surname = request.Surname;
            pax.TCKN = request.TCKN;
            pax.PhoneNumber = request.PhoneNumber;
            pax.DateOfBirth = request.DateOfBirth;

            await _paxRepository.UpdateAsync(pax);

            return true;
        }
    }


}