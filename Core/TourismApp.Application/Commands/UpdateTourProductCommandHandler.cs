using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Application.Commands;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.CommandHandlers
{
    public class UpdateTourProductCommandHandler : IRequestHandler<UpdateTourProductCommand, Guid>
    {
        private readonly ITourProductRepository _repository;

        public UpdateTourProductCommandHandler(ITourProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateTourProductCommand request, CancellationToken cancellationToken)
        {
            var tourProduct = new TourProduct
            {
                Id = request.Id,
                TourId = request.TourId,
                SalesStartDate = request.SalesStartDate,
                SalesEndDate = request.SalesEndDate,
                TourStartDate = request.TourStartDate,
                TourEndDate = request.TourEndDate
            };

            await _repository.UpdateAsync(tourProduct);

            return tourProduct.Id;
        }
    }
}
