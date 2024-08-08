using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IOrderTourProductPriceRepository
    {
        Task<List<OrderTourProductPrice>> GetAllAsync();
        Task<OrderTourProductPrice> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(OrderTourProductPrice orderTourProductPrice);
        Task UpdateAsync(OrderTourProductPrice orderTourProductPrice);
        Task DeleteAsync(Guid id);
    }

}