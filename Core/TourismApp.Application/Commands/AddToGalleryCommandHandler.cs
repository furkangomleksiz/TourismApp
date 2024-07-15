using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class AddToGalleryCommandHandler : IRequestHandler<AddToGalleryCommand, bool>
{
    private readonly ITourRepository _tourRepository;

    public AddToGalleryCommandHandler(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task<bool> Handle(AddToGalleryCommand request, CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetTourByIdAsync(request.TourId);
        if (tour == null)
            throw new Exception("Tour not found");

        // Add the image to the gallery
        tour.Gallery.Add(new TourImage { ImageUrl = request.ImageUrl });

        // Update the tour in the repository
        await _tourRepository.UpdateTourAsync(tour);

        return true;
    }
}
}