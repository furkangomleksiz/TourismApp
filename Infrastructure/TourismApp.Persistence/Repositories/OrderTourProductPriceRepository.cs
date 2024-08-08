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
    public class OrderTourProductPriceRepository : IOrderTourProductPriceRepository
    {
        private readonly TourContext _context;

        public OrderTourProductPriceRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<List<OrderTourProductPrice>> GetAllAsync()
        {
            return await _context.OrderTourProductPrices
                                 .Include(otpp => otpp.Order)
                                 .Include(otpp => otpp.TourProductPrice)
                                 .Where(otpp => otpp.Order.DeletedAt == null)
                                 .ToListAsync();
        }

        public async Task<OrderTourProductPrice> GetByIdAsync(Guid id)
        {
            return await _context.OrderTourProductPrices
                .Include(otpp => otpp.Order)
                .Include(otpp => otpp.TourProductPrice)
                .Where(otpp => otpp.Id == id && otpp.Order.DeletedAt == null)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(OrderTourProductPrice orderTourProductPrice)
        {
            _context.OrderTourProductPrices.Add(orderTourProductPrice);
            await _context.SaveChangesAsync();
            return orderTourProductPrice.Id;
        }

        public async Task UpdateAsync(OrderTourProductPrice orderTourProductPrice)
        {
            _context.Entry(orderTourProductPrice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderTourProductPrice = await _context.OrderTourProductPrices.FindAsync(id);
            if (orderTourProductPrice != null)
            {
                _context.OrderTourProductPrices.Remove(orderTourProductPrice);
                await _context.SaveChangesAsync();
            }
        }
    }

}