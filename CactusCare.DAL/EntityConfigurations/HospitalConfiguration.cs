using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL.EntityConfigurations
{
    class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            //this data was added for the testing purpose,
            //it's better to use dataseeder instead of entity.HasData()
            builder.HasData(
                new Hospital()
                {
                    Id = 1, Name = "Лікарня 1", Address = "Адреса 1", Email = "емейл@емейл1",
                    PhoneNumber = "(032) 345 45", Website = "hos1.com"
                },
                new Hospital()
                {
                    Id = 2, Name = "Лікарня 2", Address = "Адреса 2", Email = "емейл@емейл2",
                    PhoneNumber = "(032) 756 64", Website = "hos2.com"
                });
        }
    }
}
