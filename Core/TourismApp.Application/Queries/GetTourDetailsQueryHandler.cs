using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TourismApp.Domain.Interfaces;
using TourismApp.Application.DTOs;
using TourismApp.Application.Queries;

namespace TourismApp.Application.Tours.Queries
{
    public class GetTourDetailsQueryHandler : IRequestHandler<GetTourDetailsQuery, TourDetailsDTO>
{
    private readonly ITourRepository _tourRepository;

    public GetTourDetailsQueryHandler(ITourRepository tourRepository)
    {
        _tourRepository = tourRepository;
    }

    public async Task<TourDetailsDTO> Handle(GetTourDetailsQuery request, CancellationToken cancellationToken)
    {
        var tour = await _tourRepository.GetTourByIdAsync(request.Id);
        if (tour == null || tour.DeletedAt != null)
            throw new Exception("Tour not found");

        return new TourDetailsDTO
        {
            Id = tour.Id,
            Title = tour.Title,
            GeneralInfo = tour.GeneralInfo,
            SlugUrl = tour.SlugUrl,
            Image = tour.Image,
            DayNum = tour.DayNum,
            NightNum = tour.NightNum,
            IsActive = tour.IsActive,
            TourProducts = tour.TourProducts.Where(tp => tp.DeletedAt == null).Select(tp => new TourProductDto
            {
                Id = tp.Id,
                SalesStartDate = tp.SalesStartDate,
                SalesEndDate = tp.SalesEndDate,
                TourStartDate = tp.TourStartDate,
                TourEndDate = tp.TourEndDate
            }).ToList(),
            GalleryImages = tour.Gallery
        };
    }
}
}
