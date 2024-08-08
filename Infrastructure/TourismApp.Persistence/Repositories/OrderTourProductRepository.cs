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
    public class OrderTourProductRepository : IOrderTourProductRepository
    {
        private readonly TourContext _context;

        public OrderTourProductRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<List<OrderTourProduct>> GetAllAsync()
        {
            return await _context.OrderTourProducts
                                 .Include(otp => otp.Order)
                                 .Include(otp => otp.TourProduct)
                                 .Where(otp => otp.Order.DeletedAt == null && otp.TourProduct.DeletedAt == null)
                                 .ToListAsync();
        }

        public async Task<OrderTourProduct> GetByIdAsync(Guid id)
        {
            return await _context.OrderTourProducts
                .Include(otp => otp.Order)
                .Include(otp => otp.TourProduct)
                .Where(otp => otp.Id == id && otp.Order.DeletedAt == null && otp.TourProduct.DeletedAt == null)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(OrderTourProduct orderTourProduct)
        {
            _context.OrderTourProducts.Add(orderTourProduct);
            await _context.SaveChangesAsync();
            return orderTourProduct.Id;
        }

        public async Task UpdateAsync(OrderTourProduct orderTourProduct)
        {
            _context.Entry(orderTourProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderTourProduct = await _context.OrderTourProducts.FindAsync(id);
            if (orderTourProduct != null)
            {
                _context.OrderTourProducts.Remove(orderTourProduct);
                await _context.SaveChangesAsync();
            }
        }
    }

}