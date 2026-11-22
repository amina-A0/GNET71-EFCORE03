using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_3
{
    public static class DbInitializer
    {
        public static void Seed(OnlineLearningContext context)
        {
            // Seed Students only when the table is empty
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        FullName = "Ali Mohamed",
                        Email = "ali@example.com",
                        DateOfBirth = new DateTime(2002, 5, 10)
                    },
                    new Student
                    {
                        FullName = "Sara Ahmed",
                        Email = "sara@example.com",
                        DateOfBirth = new DateTime(2001, 8, 15)
                    },
                    new Student
                    {
                        FullName = "Omar Samir",
                        Email = "omar.student@example.com",
                        DateOfBirth = new DateTime(2003, 2, 20)
                    },
                    new Student
                    {
                        FullName = "Mariam Adel",
                        Email = "mariam@example.com",
                        DateOfBirth = new DateTime(2002, 11, 5)
                    },
                    new Student
                    {
                        FullName = "Youssef Hany",
                        Email = "youssef@example.com",
                        DateOfBirth = new DateTime(2000, 7, 25)
                    }
                };

                context.Students.AddRange(students);
                context.SaveChanges();
            }

            // Seed Enrollments only when the table is empty
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 1, 15),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 95
                    },
                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 2, 15),
                        Progress = 40,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = 2,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 1, 20),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 88
                    },
                    new Enrollment
                    {
                        StudentId = 2,
                        CourseId = 3,
                        EnrollmentDate = new DateTime(2026, 3, 15),
                        Progress = 20,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 3,
                        EnrollmentDate = new DateTime(2026, 3, 20),
                        Progress = 0,
                        Status = EnrollmentStatus.Dropped,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 5,
                        EnrollmentDate = new DateTime(2026, 4, 15),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 90
                    },
                    new Enrollment
                    {
                        StudentId = 4,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 4, 20),
                        Progress = 10,
                        Status = EnrollmentStatus.Dropped,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = 5,
                        CourseId = 5,
                        EnrollmentDate = new DateTime(2026, 4, 25),
                        Progress = 60,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    }
                };

                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}
