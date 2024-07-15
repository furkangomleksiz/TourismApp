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
        private readonly ITourRepository _repository;

        public GetTourDetailsQueryHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public async Task<TourDetailsDTO> Handle(GetTourDetailsQuery request, CancellationToken cancellationToken)
        {
            var tour = await _repository.GetTourByIdAsync(request.Id);

            if (tour == null)
            {
                throw new Exception("Tour not found"); // Or handle the not found case as needed
            }

            var currentDate = DateTime.UtcNow;

            var tourDetailsDto = new TourDetailsDTO
            {
                Id = tour.Id,
                Title = tour.Title,
                GeneralInfo = tour.GeneralInfo,
                SlugUrl = tour.SlugUrl,
                Image = tour.Image,
                DayNum = tour.DayNum,
                NightNum = tour.NightNum,
                IsActive = tour.IsActive,
                GalleryImages = tour.Gallery,
                TourProducts = tour.TourProducts
                    .Where(tp => tp.SalesEndDate >= currentDate)
                    .Select(tp => new TourProductDto
                    {
                        Id = tp.Id,
                        TourId = tp.TourId,
                        SalesStartDate = tp.SalesStartDate,
                        SalesEndDate = tp.SalesEndDate,
                        TourStartDate = tp.TourStartDate,
                        TourEndDate = tp.TourEndDate
                    }).ToList()
            };

            return tourDetailsDto;
        }
    }
}
