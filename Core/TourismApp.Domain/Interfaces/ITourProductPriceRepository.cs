using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface ITourProductPriceRepository
    {
        Task<List<TourProductPrice>> GetAllAsync();
        Task<TourProductPrice> GetByIdAsync(Guid id);
        Task<TourProductPrice> GetByTypeAsync(Guid tourProductId, PriceType priceType);
        Task<Guid> CreateAsync(TourProductPrice tourProductPrice);
        Task UpdateAsync(TourProductPrice tourProductPrice);
        Task DeleteAsync(Guid id);
    }

}