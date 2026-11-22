using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_3
{
    public class PlatformOperations
    {
        private readonly OnlineLearningContext _context;

        public PlatformOperations(OnlineLearningContext context)
        {
            _context = context;
        }

     
        // CREATE
       
        // 1. Add Instructor
        public void AddInstructor()
        {
            var instructor = new Instructor
            {
                FullName = "Nour Mostafa",
                Email = "nour@example.com",
                Bio = "Software Instructor",
                JoinedDate = DateTime.Now
            };

            _context.Instructors.Add(instructor);
            _context.SaveChanges();

            Console.WriteLine(
                $"Instructor added. Id: {instructor.Id}");
        }

        // 2. Add Course
        public void AddCourse()
        {
            int instructorId = 1;
            int categoryId = 3;

            bool instructorExists =
                _context.Instructors.Any(i => i.Id == instructorId);

            bool categoryExists =
                _context.Categories.Any(c => c.Id == categoryId);

            if (!instructorExists || !categoryExists)
            {
                Console.WriteLine(
                    "Cannot add course: instructor or category not found.");
                return;
            }

            var course = new Course
            {
                Title = "Entity Framework Core",
                Description = "EF Core Practical Course",
                Price = 750,
                Level = CourseLevel.Intermediate,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            Console.WriteLine($"Course added. Id: {course.Id}");
        }

        // 3. Add Several Students
        public void AddSeveralStudents()
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Hana Ahmed",
                    Email = "hana@example.com",
                    DateOfBirth = new DateTime(2002, 4, 5)
                },
                new Student
                {
                    FullName = "Khaled Ali",
                    Email = "khaled@example.com",
                    DateOfBirth = new DateTime(2001, 6, 10)
                },
                new Student
                {
                    FullName = "Salma Mostafa",
                    Email = "salma@example.com",
                    DateOfBirth = new DateTime(2003, 9, 12)
                }
            };

            _context.Students.AddRange(students);
            _context.SaveChanges();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Student added: {student.FullName}, Id: {student.Id}");
            }
        }

        // 4. Enroll Student
        public void EnrollStudent()
        {
            int studentId = 1;
            int courseId = 1;

            var student = _context.Students.Find(studentId);
            var course = _context.Courses.Find(courseId);

            if (student == null)
            {
                Console.WriteLine("Enrollment refused: student not found.");
                return;
            }

            if (course == null)
            {
                Console.WriteLine("Enrollment refused: course not found.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine(
                    "Enrollment refused: course is not published.");
                return;
            }

            bool alreadyEnrolled = _context.Enrollments.Any(
                e => e.StudentId == studentId &&
                     e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine(
                    "Enrollment refused: student is already enrolled.");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                Progress = 0,
                Status = EnrollmentStatus.Active,
                FinalGrade = null
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            Console.WriteLine("Student enrolled successfully.");
        }

        
        // READ
        

        // 5. Find Course
        public void FindCourse()
        {
            int courseId = 1;

            var courseById = _context.Courses.Find(courseId);

            if (courseById == null)
                Console.WriteLine("Course not found by Id.");
            else
                Console.WriteLine(
                    $"Found by Id: {courseById.Title}");

            string title = "ASP.NET Core";

            var courseByTitle = _context.Courses
                .FirstOrDefault(c => c.Title == title);

            if (courseByTitle == null)
                Console.WriteLine("Course not found by title.");
            else
                Console.WriteLine(
                    $"Found by title: {courseByTitle.Title}");
        }

        // 6. Filter Courses
        public void FilterCourses()
        {
            decimal minPrice = 400;
            decimal maxPrice = 900;

            var courses = _context.Courses
                .Where(c => c.Price >= minPrice &&
                            c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new
                {
                    c.Title,
                    c.Level,
                    c.Price
                })
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Title} | {course.Level} | {course.Price}");
            }
        }

        // 7. Subcategories and Top-Level Categories
        public void PrintCategories()
        {
            int categoryId = 1;

            var subCategories = _context.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            Console.WriteLine("Direct Subcategories:");

            foreach (var category in subCategories)
                Console.WriteLine(category.Name);

            var topLevelCategories = _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top-Level Categories:");

            foreach (var category in topLevelCategories)
                Console.WriteLine(category.Name);
        }

        // 8. Course Roster
        public void PrintCourseRoster()
        {
            int courseId = 1;

            int enrollmentCount = _context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Number of enrolled students: {enrollmentCount}");

            var studentIds = _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            var students = _context.Students
                .Where(s => studentIds.Contains(s.Id))
                .ToList();

            foreach (var student in students)
                Console.WriteLine(student.FullName);
        }

        // UPDATE
     
        // 9. Change Price
        public void ChangePrice()
        {
            int courseId = 1;

            var course = _context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.Price = 600;

            _context.SaveChanges();

            Console.WriteLine("Course price updated.");
        }

        // 10. Update Progress
        public void UpdateProgress()
        {
            int studentId = 1;
            int courseId = 2;
            decimal newProgress = 100;

            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine(
                    "Invalid progress. It must be between 0 and 100.");
                return;
            }

            var enrollment = _context.Enrollments.Find(
                studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            enrollment.Progress = newProgress;

            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }

            _context.SaveChanges();

            Console.WriteLine("Progress updated successfully.");
        }

        // 11. Publish Course
        public void PublishCourse()
        {
            int courseId = 4;

            var course = _context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;

            _context.SaveChanges();

            Console.WriteLine("Course published successfully.");
        }

        
        // DELETE
      

        // 12. Unenroll
        public void UnenrollStudent()
        {
            int studentId = 1;
            int courseId = 2;

            var enrollment = _context.Enrollments.Find(
                studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            Console.WriteLine("Student unenrolled successfully.");
        }

        // 13. Delete Category - Unsafe Attempt
        public void TryDeleteCategory()
        {
            int categoryId = 1;

            var category = _context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

                Console.WriteLine("Category deleted.");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine(
                    "Cannot delete category because it has subcategories or related courses.");

                _context.ChangeTracker.Clear();
            }
        }

        // 14. Safe Delete Category
        public void SafeDeleteCategory()
        {
            int categoryId = 1;

            var category = _context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            bool hasSubCategories = _context.Categories
                .Any(c => c.ParentCategoryId == categoryId);

            if (hasSubCategories)
            {
                Console.WriteLine(
                    "Cannot delete category: it has subcategories.");
                return;
            }

            bool hasCourses = _context.Courses
                .Any(c => c.CategoryId == categoryId);

            if (hasCourses)
            {
                Console.WriteLine(
                    "Cannot delete category: it has courses.");
                return;
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            Console.WriteLine("Category deleted successfully.");
        }

        // 15. Delete Course with Enrollments
        public void DeleteCourse()
        {
            int courseId = 3;

            int before = _context.Enrollments
                .Count(e => e.CourseId == courseId);

            var course = _context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            int after = _context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Enrollments before deletion: {before}");

            Console.WriteLine(
                $"Enrollments after deletion: {after}");

            // Related enrollments were removed because the Course relationship uses Cascade delete.
        }

        // BULK op
        // 16. Bulk Price Raise
        public async Task BulkPriceRaise()
        {
            var affectedRows = await _context.Courses
                .Where(c => c.IsPublished &&
                            c.Level == CourseLevel.Beginner)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(
                        c => c.Price,
                        c => c.Price * 1.10m
                    ));

            Console.WriteLine(
                $"Courses updated: {affectedRows}");
        }

        // 17. Bulk Delete Dropped Enrollments
        public async Task BulkDeleteDroppedEnrollments()
        {
            var affectedRows = await _context.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDeleteAsync();

            Console.WriteLine(
                $"Dropped enrollments deleted: {affectedRows}");
        }
    }
}