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
    private readonly ITourRepository _tourRepository;

    public GetAllToursQueryHandler(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task<List<TourDTO>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
    {
        var tours = await _tourRepository.GetAllToursAsync();
        // Filter out tours with deleted products
        //tours = tours.Where(t => t.TourProducts.Any(tp => tp.DeletedAt == null)).ToList();

        var tourDtos = tours.Select(t => new TourDTO
        {
            Id = t.Id,
            Title = t.Title,
            TourProducts = t.TourProducts.Where(tp => tp.DeletedAt == null).Select(tp => new TourProductDto
            {
                Id = tp.Id,
                SalesStartDate = tp.SalesStartDate,
                SalesEndDate = tp.SalesEndDate,
                TourStartDate = tp.TourStartDate,
                TourEndDate = tp.TourEndDate
            }).ToList()
        }).ToList();

        return tourDtos;
    }
}
}
