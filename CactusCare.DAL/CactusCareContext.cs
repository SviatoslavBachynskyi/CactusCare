using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL
{
    internal class CactusCareContext : DbContext
    {
        public DbSet<Speciality> Specialities { get; set; }

        public CactusCareContext(DbContextOptions<CactusCareContext> contextOptions)
            : base(contextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Speciality>((entity) =>
            {
                entity.HasData(new Speciality() { Id = 1, Name = "тест" },
                    new Speciality() { Id = 2, Name = "тест 2" });
            });
        }
    }
}
