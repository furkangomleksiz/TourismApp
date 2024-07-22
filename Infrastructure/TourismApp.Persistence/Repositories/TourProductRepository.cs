using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismApp.Domain.Entities;
using TourismApp.Domain.Interfaces;
using TourismApp.Persistence;
using TourismApp.Persistence.Data;

namespace TourismApp.Infrastructure.Repositories
{
    public class TourProductRepository : ITourProductRepository
    {
        private readonly TourContext _context;

        public TourProductRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<List<TourProduct>> GetAllAsync()
        {
            return await _context.TourProducts
                                .Where(tp => tp.DeletedAt == null)
                                .ToListAsync();
        }

        public async Task<TourProduct> GetByIdAsync(Guid id)
        {
            return await _context.TourProducts
                .Where(tp => tp.Id == id && tp.DeletedAt == null)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(TourProduct tourProduct)
        {
            _context.TourProducts.Add(tourProduct);
            await _context.SaveChangesAsync();
            return tourProduct.Id;
        }

        public async Task UpdateAsync(TourProduct tourProduct)
        {
            _context.Entry(tourProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tourProduct = await _context.TourProducts.FindAsync(id);
            if (tourProduct != null)
            {
                _context.TourProducts.Remove(tourProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
