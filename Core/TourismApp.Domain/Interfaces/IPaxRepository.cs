using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismApp.Domain.Entities;

namespace TourismApp.Domain.Interfaces
{
    public interface IPaxRepository
{
    Task<Pax> GetByIdAsync(Guid id);
    Task<IEnumerable<Pax>> GetAllByOrderIdAsync(Guid orderId);
    Task AddAsync(Pax pax);
    Task UpdateAsync(Pax pax);
    Task DeleteAsync(Guid id);
}
}