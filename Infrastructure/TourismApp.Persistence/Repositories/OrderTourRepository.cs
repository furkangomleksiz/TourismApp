using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TourismApp.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using TourismApp.Domain.Entities;
    using TourismApp.Domain.Interfaces;
    using TourismApp.Persistence.Data;

    public class OrderTourRepository : IOrderTourRepository
{
    private readonly TourContext _context;

    public OrderTourRepository(TourContext context)
    {
        _context = context;
    }

    public async Task<List<OrderTour>> GetAllAsync()
    {
        return await _context.OrderTours
                             .Include(ot => ot.Tour)
                             .Include(ot => ot.Order)
                             .Where(ot => ot.Order.DeletedAt == null)
                             .ToListAsync();
    }

    public async Task<OrderTour> GetByIdAsync(Guid id)
    {
        return await _context.OrderTours
                             .Include(ot => ot.Tour)
                             .Include(ot => ot.Order)
                             .Where(ot => ot.Id == id && ot.Order.DeletedAt == null)
                             .FirstOrDefaultAsync();
    }

    public async Task<Guid> CreateAsync(OrderTour orderTour)
    {
        _context.OrderTours.Add(orderTour);
        await _context.SaveChangesAsync();
        return orderTour.Id;
    }

    public async Task UpdateAsync(OrderTour orderTour)
    {
        _context.Entry(orderTour).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var orderTour = await _context.OrderTours.FindAsync(id);
        if (orderTour != null)
        {
            _context.OrderTours.Remove(orderTour); // Physical deletion
            await _context.SaveChangesAsync();
        }
    }
}

}