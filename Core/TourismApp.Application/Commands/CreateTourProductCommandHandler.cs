using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Application.Commands;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.CommandHandlers
{
    public class CreateTourProductCommandHandler : IRequestHandler<CreateTourProductCommand, Guid>
    {
        private readonly ITourProductRepository _repository;

        public CreateTourProductCommandHandler(ITourProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTourProductCommand request, CancellationToken cancellationToken)
        {
            var tourProduct = new TourProduct
            {
                TourId = request.TourId,
                SalesStartDate = request.SalesStartDate,
                SalesEndDate = request.SalesEndDate,
                TourStartDate = request.TourStartDate,
                TourEndDate = request.TourEndDate,
                Price = request.Price
            };

            await _repository.CreateAsync(tourProduct);

            return tourProduct.Id;
        }
    }
}
