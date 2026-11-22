using EfCore_3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_3
{
    public class StudentConfiguration
        : IEntityTypeConfiguration<Student>
    {
        public void Configure(
            EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.DateOfBirth)
                .IsRequired();

            builder.HasIndex(s => s.Email)
                .IsUnique();
        }
    }
}
