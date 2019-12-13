using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CactusCare.DAL.EntityConfigurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(d => d.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .HasConstraintName("FK_Doctor_Speciality")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Hospital)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_Doctor_Hospital")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.Id).ValueGeneratedOnAdd();
        }
    }
}