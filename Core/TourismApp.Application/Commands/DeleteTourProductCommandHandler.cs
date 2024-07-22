using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Commands
{
    public class DeleteTourProductCommandHandler : IRequestHandler<DeleteTourProductCommand>
    {
        private readonly ITourProductRepository _tourProductRepository;

        public DeleteTourProductCommandHandler(ITourProductRepository tourProductRepository)
        {
            _tourProductRepository = tourProductRepository;
        }

        public async Task Handle(DeleteTourProductCommand request, CancellationToken cancellationToken)
        {
            var tourProduct = await _tourProductRepository.GetByIdAsync(request.Id);
            if (tourProduct == null) throw new Exception("Tour not found");

            tourProduct.DeletedAt = DateTime.UtcNow;
            await _tourProductRepository.UpdateAsync(tourProduct);
        }
    }
}
