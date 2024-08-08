using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IOrderTourProductRepository
    {
        Task<List<OrderTourProduct>> GetAllAsync();
        Task<OrderTourProduct> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(OrderTourProduct orderTourProduct);
        Task UpdateAsync(OrderTourProduct orderTourProduct);
        Task DeleteAsync(Guid id);
    }

}