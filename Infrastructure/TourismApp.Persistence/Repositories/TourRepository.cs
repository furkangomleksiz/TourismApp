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
            // Retrieve the tour by Id and ensure it's not deleted
            var tour = await _context.Tours
                .Where(t => t.Id == id && t.DeletedAt == null)
                .Include(t => t.Gallery)
                .FirstOrDefaultAsync();

            if (tour == null)
                return null; // Or throw an exception if appropriate

            // Manually filter the related TourProducts after retrieving the tour
            tour.TourProducts = tour.TourProducts
                .Where(tp => tp.SalesEndDate > DateTime.UtcNow)
                .ToList();

            return tour;
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _context.Tours
                .Include(t => t.TourProducts.Where(tp => tp.SalesEndDate > DateTime.UtcNow && tp.DeletedAt == null))
                .Include(t => t.Gallery)
                .Where(t => t.DeletedAt == null)
                .ToListAsync();
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
