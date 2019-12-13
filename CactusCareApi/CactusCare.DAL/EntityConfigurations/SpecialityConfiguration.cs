using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CactusCare.DAL.EntityConfigurations
{
    internal class SpecialityConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}