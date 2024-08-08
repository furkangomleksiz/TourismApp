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
        public DbSet<TourProductPrice> TourProductPrices { get; set; }
        public DbSet<OrderTour> OrderTours { get; set; }
        public DbSet<OrderTourProduct> OrderTourProducts { get; set; }
        public DbSet<OrderTourProductPrice> OrderTourProductPrices { get; set; }



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

            modelBuilder.Entity<OrderTour>()
                .HasKey(ot => ot.Id);

            modelBuilder.Entity<OrderTour>()
                .HasOne(ot => ot.Order)
                .WithMany()
                .HasForeignKey(ot => ot.OrderId);

            modelBuilder.Entity<OrderTour>()
                .HasOne(ot => ot.Tour)
                .WithMany()
                .HasForeignKey(ot => ot.TourId);

            modelBuilder.Entity<OrderTourProduct>()
                .HasKey(otp => new { otp.OrderId, otp.TourProductId });

            modelBuilder.Entity<OrderTourProduct>()
                .HasOne(otp => otp.Order)
                .WithMany()
                .HasForeignKey(otp => otp.OrderId);

            modelBuilder.Entity<OrderTourProduct>()
                .HasOne(otp => otp.TourProduct)
                .WithMany()
                .HasForeignKey(otp => otp.TourProductId);

            modelBuilder.Entity<OrderTourProductPrice>()
                .HasKey(otpp => new { otpp.OrderId, otpp.TourProductPriceId });

            modelBuilder.Entity<OrderTourProductPrice>()
                .HasOne(otpp => otpp.Order)
                .WithMany()
                .HasForeignKey(otpp => otpp.OrderId);

            modelBuilder.Entity<OrderTourProductPrice>()
                .HasOne(otpp => otpp.TourProductPrice)
                .WithMany()
                .HasForeignKey(otpp => otpp.TourProductPriceId);

            modelBuilder.Entity<TourProductPrice>()
                .Property(tpp => tpp.PriceType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}