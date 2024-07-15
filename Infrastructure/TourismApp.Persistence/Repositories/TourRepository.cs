using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;
using TourismApp.Persistence.Data;

namespace TourismApp.Persistence.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly TourContext _context;

        public TourRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<Tour> GetTourByIdAsync(Guid id)
        {
            return await _context.Tours
            .Include(t => t.TourProducts.Where(tp => tp.SalesEndDate > DateTime.UtcNow))
            .Include(t => t.Gallery).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _context.Tours
            .Include(t => t.TourProducts.Where(tp => tp.SalesEndDate > DateTime.UtcNow))
            .Include(t => t.Gallery).ToListAsync();
        }

        public async Task AddTourAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTourAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(Guid id)
        {
            var tour = await GetTourByIdAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
