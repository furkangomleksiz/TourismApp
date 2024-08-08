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
    public class TourProductPriceRepository : ITourProductPriceRepository
    {
        private readonly TourContext _context;

        public TourProductPriceRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<List<TourProductPrice>> GetAllAsync()
        {
            return await _context.TourProductPrices
                                 .Include(tpp => tpp.TourProduct)
                                 .Where(tpp => tpp.TourProduct.DeletedAt == null)
                                 .ToListAsync();
        }

        public async Task<TourProductPrice> GetByIdAsync(Guid id)
        {
            return await _context.TourProductPrices
                                 .Include(tpp => tpp.TourProduct)
                                 .Where(tpp => tpp.Id == id && tpp.TourProduct.DeletedAt == null)
                                 .FirstOrDefaultAsync();
        }

        public async Task<TourProductPrice> GetByTypeAsync(Guid tourProductId, PriceType priceType)
        {
            return await _context.TourProductPrices
                                 .Include(tpp => tpp.TourProduct)
                                 .Where(tpp => tpp.TourProductId == tourProductId && tpp.PriceType == priceType && tpp.TourProduct.DeletedAt == null)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(TourProductPrice tourProductPrice)
        {
            _context.TourProductPrices.Add(tourProductPrice);
            await _context.SaveChangesAsync();
            return tourProductPrice.Id;
        }

        public async Task UpdateAsync(TourProductPrice tourProductPrice)
        {
            _context.Entry(tourProductPrice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tourProductPrice = await _context.TourProductPrices.FindAsync(id);
            if (tourProductPrice != null)
            {
                _context.TourProductPrices.Remove(tourProductPrice); // Physical deletion
                await _context.SaveChangesAsync();
            }
        }
    }


}