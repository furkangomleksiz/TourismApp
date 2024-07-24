using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismApp.Domain.Entities;

namespace TourismApp.Persistence.Data
{
    public class TourContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<TourProduct> TourProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pax> Paxes { get; set; }


        public TourContext(DbContextOptions<TourContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.Gallery)
                .WithOne(ti => ti.Tour)
                .HasForeignKey(ti => ti.TourId);
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.TourProducts)
                .WithOne(tp => tp.Tour)
                .HasForeignKey(tp => tp.TourId);

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            modelBuilder.Entity<TourProduct>()
                .HasMany(tp => tp.Orders)
                .WithOne(o => o.TourProduct)
                .HasForeignKey(o => o.TourProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.TourProduct)
                .WithMany(tp => tp.Orders)
                .HasForeignKey(o => o.TourProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pax>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Paxes)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);
        }
    }
}