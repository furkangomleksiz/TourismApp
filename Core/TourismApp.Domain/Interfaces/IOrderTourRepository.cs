using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IOrderTourRepository
    {
        Task<List<OrderTour>> GetAllAsync();
        Task<OrderTour> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(OrderTour orderTour);
        Task UpdateAsync(OrderTour orderTour);
        Task DeleteAsync(Guid id);
    }
}