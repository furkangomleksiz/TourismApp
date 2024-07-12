using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Guid>
{
    private readonly ITourRepository _tourRepository;

    public UpdateTourCommandHandler(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task<Guid> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetTourByIdAsync(request.Id);

        if (tour == null)
        {
            throw new Exception("Tour not found");
        }

        tour.Title = request.Title;
        tour.GeneralInfo = request.GeneralInfo;
        tour.SlugUrl = request.SlugUrl;
        tour.Image = request.Image;
        tour.DayNum = request.DayNum;
        tour.NightNum = request.NightNum;
        tour.Gallery = request.Gallery;
        tour.IsActive = request.IsActive;

        await _tourRepository.UpdateTourAsync(tour);

        return tour.Id;
    }
}

}