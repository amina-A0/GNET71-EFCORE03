using EfCore_3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_3
{
    public class EnrollmentConfiguration
        : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(
            EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new
            {
                e.StudentId,
                e.CourseId
            });

            builder.Property(e => e.EnrollmentDate)
                .IsRequired();

            builder.Property(e => e.Progress)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.Property(e => e.FinalGrade)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Enrollment_Progress",
                    "[Progress] >= 0 AND [Progress] <= 100"
                );
            });
        }
    }
}
