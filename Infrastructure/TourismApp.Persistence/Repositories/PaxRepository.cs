using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;
using TourismApp.Persistence.Data;

namespace TourismApp.Persistence.Repositories
{
    public class PaxRepository : IPaxRepository
{
    private readonly TourContext _context;

    public PaxRepository(TourContext context)
    {
        _context = context;
    }

    public async Task<Pax> GetByIdAsync(Guid id)
    {
        return await _context.Paxes.FindAsync(id);
    }

    public async Task<IEnumerable<Pax>> GetAllByOrderIdAsync(Guid orderId)
    {
        return await _context.Paxes
            .Where(p => p.OrderId == orderId)
            .ToListAsync();
    }

    public async Task AddAsync(Pax pax)
    {
        await _context.Paxes.AddAsync(pax);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pax pax)
    {
        _context.Paxes.Update(pax);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var pax = await _context.Paxes.FindAsync(id);
        if (pax != null)
        {
            _context.Paxes.Remove(pax);
            await _context.SaveChangesAsync();
        }
    }
}
}