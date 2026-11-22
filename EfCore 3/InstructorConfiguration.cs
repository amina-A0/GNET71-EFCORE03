using EfCore_3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcore_3
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.Bio)
                .HasMaxLength(500);

            builder.Property(i => i.JoinedDate)
                .IsRequired();

            builder.HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Bio = "C# Instructor",
                    JoinedDate = new DateTime(2025, 1, 1)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    Bio = "Backend Instructor",
                    JoinedDate = new DateTime(2025, 2, 1)
                },
                new Instructor
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "omar@example.com",
                    Bio = null,
                    JoinedDate = new DateTime(2025, 3, 1)
                }
            );
        }
    }
}