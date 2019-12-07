﻿using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CactusCare.DAL.EntityConfigurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(d => d.Doctor)
                .WithMany(s => s.Reviews)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Doctor_Review");
        }
    }
}