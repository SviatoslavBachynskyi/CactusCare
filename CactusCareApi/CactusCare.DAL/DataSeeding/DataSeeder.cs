using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace CactusCare.DAL.DataSeeding
{
    public static class DataSeeder
    {
        public static void SeedEssentialData(CactusCareContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            string adminPassword)
            => SeedEssentialDataAsync(context, roleManager, userManager, adminPassword).Wait();

        public static async Task SeedEssentialDataAsync
            (
            CactusCareContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            string adminPassword
            )
        {
            await SeedRolesAsync(roleManager);
            await CreateAdmin(userManager, adminPassword);
            await context.SaveChangesAsync();
        }

        public static void SeedTestData(CactusCareContext context) => SeedTestDataAsync(context).Wait();

        public static async Task SeedTestDataAsync(CactusCareContext context)
        {
            if (context.Specialties.Any()) return;

            #region Specialties

            var therapist = new Specialty() { Name = "Терапевт" };
            var dentist = new Specialty() { Name = "Стоматолог" };

            context.Specialties.AddRange(therapist, dentist);
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
                Patronymic = "Іванович",
                LastName = "Шевчук",
                Specialty = therapist,
                Hospital = studentHospital,
                Rating = 3f
            };
            var Dmytrenko = new Doctor()
            {
                FirstName = "Катерина",
                Patronymic = "Олександрівна",
                LastName = "Дмитренко",
                Specialty = dentist,
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

            await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole("Admin"));
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole("Reviewer"));
        }

        private static async Task CreateRoleIfNotExistsAsync(RoleManager<IdentityRole> roleManager, IdentityRole role)
        {
            if (await roleManager.FindByNameAsync(role.Name) == null)
            {
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task CreateAdmin(UserManager<User> userManager, string adminPassword)
        {
            var user = new User() { UserName = "Admin" };

            if (await userManager.FindByNameAsync(user.UserName) != null) return;

            var createResult = await userManager.CreateAsync(user, adminPassword);

            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}