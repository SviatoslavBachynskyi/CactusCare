﻿using System;
using System.Collections.Generic;
using System.Linq;
using CactusCare.Abstractions.Entities;

namespace CactusCare.DAL.DataSeeding
{
    public static class DataSeeder
    {
        public static void SeedAdditional(CactusCareContext context)
        {
            if (context.Specialities.Any()) return;

            #region Specialities

            var therapist = new Speciality() { Name = "Терапевт" };
            var dentist = new Speciality() { Name = "Стоматолог" };

            context.Specialities.AddRange(therapist, dentist);
            #endregion

            #region Hospitals

            var studentHospital = new Hospital()
            {
                Name = "Десята міську лікарню м.Львова",
                Address = "Бой – Желенського, 14",
                Email = "Don'tKnow@cactus.com",
                PhoneNumber = "238-56-69",
                Website = "http://likarnj10.lviv.ua/"
            };
            var secondHospital = new Hospital()
            {
                Name = "Лікарня 2",
                Address = "Адреса 2",
                Email = "емейл@емейл2",
                PhoneNumber = "(032) 756 64",
                Website = "hos2.com"
            };

            context.Hospitals.AddRange(studentHospital, secondHospital);

            #endregion

            #region Doctors

            var Schevchuk = new Doctor()
            {
                FirstName = "Йосип",
                Patronomic = "Іванович",
                LastName = "Шевчук",
                Speciality = therapist,
                Hospital = studentHospital,
                Rating = 3f
            };
            var Dmytrenko = new Doctor()
            {
                FirstName = "Катерина",
                Patronomic = "Олександрівна",
                LastName = "Дмитренко",
                Speciality = dentist,
                Hospital = secondHospital,
                Rating = 5f
            };

            context.Doctors.AddRange(Schevchuk, Dmytrenko);

            #endregion

            #region Reviews

            context.Reviews.AddRange(
                new List<Review>()
                {
                    new Review()
                    {
                        Content = "Чудовий лікар!",
                        Time = DateTime.Now,
                        Doctor = Dmytrenko,
                        Rating = 6
                    },
                    new Review
                    {
                        Content = "Погоджуюсь. Неймовірний лікар.",
                        Time = DateTime.Now,
                        Doctor = Schevchuk,
                        Rating = 4
                    },
                    new Review
                    {
                        Content = "Жахливий лікар!",
                        Time = DateTime.Now,
                        Doctor = Dmytrenko,
                        Rating = 10
                    }
                });

            #endregion

            context.SaveChanges();
        }
    }
}