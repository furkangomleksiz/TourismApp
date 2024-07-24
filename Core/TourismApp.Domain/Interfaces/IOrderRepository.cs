using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<List<Order>> GetOrdersByTourProductIdAsync(Guid tourProductId);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}