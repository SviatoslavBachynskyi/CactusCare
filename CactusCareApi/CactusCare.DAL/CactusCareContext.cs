using CactusCare.Abstractions.Entities;
using CactusCare.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CactusCare.DAL
{
    public class CactusCareContext : IdentityDbContext<User>
    {
        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Review> Reviews { get; set; }

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
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        }
    }
}