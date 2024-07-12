using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface ITourProductRepository
    {
        Task<List<TourProduct>> GetAllAsync();
        Task<TourProduct> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(TourProduct tourProduct);
        Task UpdateAsync(TourProduct tourProduct);
        Task DeleteAsync(Guid id);
    }
}
