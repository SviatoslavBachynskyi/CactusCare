using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL.EntityConfigurations
{
    class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne((d) => d.Speciality)
                .WithMany((s) => s.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK_Doctor_Speciality");

            builder.HasData(
                new Doctor() { Id = 1, FirstName = "First", LastName = "Ivanov", SpecialityId = 1 },
                new Doctor() { Id = 2, FirstName = "Secon", LastName = "Ivanov", SpecialityId =2});
        }
    }
}
