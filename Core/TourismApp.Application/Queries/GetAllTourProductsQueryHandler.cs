using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Application.Queries;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.QueryHandlers
{
    public class GetAllTourProductsQueryHandler : IRequestHandler<GetAllTourProductsQuery, List<TourProduct>>
    {
        private readonly ITourProductRepository _repository;

        public GetAllTourProductsQueryHandler(ITourProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TourProduct>> Handle(GetAllTourProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
