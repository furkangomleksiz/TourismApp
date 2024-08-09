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
    public class OrderPaymentRepository : IOrderPaymentRepository
    {
        private readonly TourContext _context;

        public OrderPaymentRepository(TourContext context)
        {
            _context = context;
        }

        public async Task<List<OrderPayment>> GetAllAsync()
        {
            return await _context.OrderPayments.ToListAsync();
        }

        public async Task<OrderPayment> GetByIdAsync(Guid id)
        {
            return await _context.OrderPayments.FindAsync(id);
        }

        public async Task<Guid> CreateAsync(OrderPayment orderPayment)
        {
            _context.OrderPayments.Add(orderPayment);
            await _context.SaveChangesAsync();
            return orderPayment.Id;
        }

        public async Task UpdateAsync(OrderPayment orderPayment)
        {
            _context.Entry(orderPayment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderPayment = await _context.OrderPayments.FindAsync(id);
            if (orderPayment != null)
            {
                _context.OrderPayments.Remove(orderPayment);
                await _context.SaveChangesAsync();
            }
        }
    }
}