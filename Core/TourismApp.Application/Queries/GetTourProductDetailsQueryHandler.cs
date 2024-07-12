using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Application.Queries;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.QueryHandlers
{
    public class GetTourProductDetailsQueryHandler : IRequestHandler<GetTourProductDetailsQuery, TourProduct>
    {
        private readonly ITourProductRepository _repository;

        public GetTourProductDetailsQueryHandler(ITourProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<TourProduct> Handle(GetTourProductDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
