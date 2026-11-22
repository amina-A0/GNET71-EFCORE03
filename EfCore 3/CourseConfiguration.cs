using EfCore_3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcore_3
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Price)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(c => c.Level)
                .IsRequired();

            builder.Property(c => c.IsPublished)
                .IsRequired();

            builder.Property(c => c.PublishedDate)
                .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "C# Basics",
                    Description = "Introduction to C#",
                    Price = 500,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 1, 10),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "Advanced C#",
                    Description = "Advanced C# programming",
                    Price = 800,
                    Level = CourseLevel.Advanced,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 2, 10),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 3,
                    Title = "ASP.NET Core",
                    Description = "Web development using ASP.NET Core",
                    Price = 1000,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 3, 10),
                    InstructorId = 2,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 4,
                    Title = "Backend Fundamentals",
                    Description = "Backend development basics",
                    Price = 650,
                    Level = CourseLevel.Beginner,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 2,
                    CategoryId = 2
                },
                new Course
                {
                    Id = 5,
                    Title = "UI Design Basics",
                    Description = "Introduction to UI Design",
                    Price = 450,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2026, 4, 10),
                    InstructorId = 3,
                    CategoryId = 5
                },
                new Course
                {
                    Id = 6,
                    Title = "Professional UI Design",
                    Description = "Advanced UI Design",
                    Price = 900,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 4
                }
            );
        }
    }
}