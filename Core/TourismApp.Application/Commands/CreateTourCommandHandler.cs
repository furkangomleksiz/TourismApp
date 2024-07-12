using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, Guid>
    {
        private readonly ITourRepository _tourRepository;

        public CreateTourCommandHandler(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<Guid> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = new Tour
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                GeneralInfo = request.GeneralInfo,
                SlugUrl = request.SlugUrl,
                Image = request.Image,
                DayNum = request.DayNum,
                NightNum = request.NightNum,
                IsActive = request.IsActive,
                Gallery = request.Gallery,
            };

            await _tourRepository.AddTourAsync(tour);

            return tour.Id;
        }
    }
}
