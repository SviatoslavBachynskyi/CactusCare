using System;
using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.DAL
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedSpecialities(modelBuilder);
            SeedHospitals(modelBuilder);
            SeedDoctors(modelBuilder);
            SeedReviews(modelBuilder);
        }

        private static void SeedSpecialities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>().HasData(new Speciality {Id = 1, Name = "тест"},
                new Speciality {Id = 2, Name = "тест 2"});
        }

        private static void SeedHospitals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
                new Hospital
                {
                    Id = 1, Name = "Лікарня 1", Address = "Адреса 1", Email = "емейл@емейл1",
                    PhoneNumber = "(032) 345 45", Website = "hos1.com"
                },
                new Hospital
                {
                    Id = 2, Name = "Лікарня 2", Address = "Адреса 2", Email = "емейл@емейл2",
                    PhoneNumber = "(032) 756 64", Website = "hos2.com"
                });
        }

        private static void SeedDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {Id = 1, FirstName = "First", LastName = "Ivanov", SpecialityId = 1, HospitalId = 1, Rating = 2.5f},
                new Doctor {Id = 2, FirstName = "Secon", LastName = "Ivanov", SpecialityId = 2, HospitalId = 2, Rating = 5.0f});
        }

        private static void SeedReviews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1, Content = "Чудовий лікар!", Time = DateTime.Now, DoctorId = 1, Rating = 6
                },
                new Review
                {
                    Id = 2, Content = "Погоджуюсь. Неймовірний лікар.", Time = DateTime.Now, DoctorId = 1,
                    Rating = 4
                },
                new Review
                {
                    Id = 3, Content = "Жахливий лікар!", Time = DateTime.Now, DoctorId = 2, Rating = 10
                });
        }
    }
}