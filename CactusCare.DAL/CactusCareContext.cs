using CactusCare.Abstractions.Entities;
using CactusCare.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL
{
    public class CactusCareContext : DbContext
    {
        public DbSet<Speciality> Specialities { get; set; }
        
        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

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
            
            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        }
    }
}
