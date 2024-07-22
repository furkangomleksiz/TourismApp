using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand>
{
    private readonly ITourRepository _tourRepository;

    public DeleteTourCommandHandler(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task Handle(DeleteTourCommand request, CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetTourByIdAsync(request.Id);
        if (tour == null) throw new Exception("Tour not found");

        tour.DeletedAt = DateTime.UtcNow;
        await _tourRepository.UpdateTourAsync(tour);
    }
}
}