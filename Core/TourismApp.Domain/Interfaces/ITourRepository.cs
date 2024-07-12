using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface ITourRepository
    {
        Task<Tour> GetTourByIdAsync(Guid id);
        Task<List<Tour>> GetAllToursAsync();
        Task AddTourAsync(Tour tour);
        Task UpdateTourAsync(Tour tour);
        Task DeleteTourAsync(Guid id);
    }
}