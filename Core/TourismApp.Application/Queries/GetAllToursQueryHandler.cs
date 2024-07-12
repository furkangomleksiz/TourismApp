using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Application.DTOs;
using TourismApp.Application.Queries;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;

namespace TourismApp.Application.Tours.Queries
{
    public class GetAllToursQueryHandler : IRequestHandler<GetAllToursQuery, List<TourDTO>>
    {
        private readonly ITourRepository _repository;

        public GetAllToursQueryHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TourDTO>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            var tours = await _repository.GetAllToursAsync();
            var tourDtos = tours.Select(tour => new TourDTO
            {
                Id = tour.Id,
                Title = tour.Title
            }).ToList();
            
            return tourDtos;
        }
    }
}
