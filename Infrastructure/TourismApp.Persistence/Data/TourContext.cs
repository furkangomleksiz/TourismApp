using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismApp.Domain.Entities;

namespace TourismApp.Persistence.Data
{
    public class TourContext: DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourImage> TourImages { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}