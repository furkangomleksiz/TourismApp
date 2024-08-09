using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IOrderPaymentRepository
    {
        Task<List<OrderPayment>> GetAllAsync();
        Task<OrderPayment> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(OrderPayment orderPayment);
        Task UpdateAsync(OrderPayment orderPayment);
        Task DeleteAsync(Guid id);
    }
}