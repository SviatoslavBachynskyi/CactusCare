using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL.EntityConfigurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne((d) => d.Speciality)
                .WithMany((s) => s.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK_Doctor_Speciality");

            builder.HasOne(d => d.Hospital)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_Doctor_Hospital");
        }
    }
}