using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL.EntityConfigurations
{
    class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            //this data was added for the testing purpose,
            //it's better to use dataseeder instead of entity.HasData()
            builder.HasData(new Speciality() { Id = 1, Name = "тест" },
                new Speciality() { Id = 2, Name = "тест 2" });
        }
    }
}
