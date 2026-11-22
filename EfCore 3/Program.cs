using EfCore_3;
using Microsoft.EntityFrameworkCore;


namespace EfCore_3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new OnlineLearningContext();

            context.Database.Migrate();
            DbInitializer.Seed(context);

            var operations = new PlatformOperations(context);

            Console.WriteLine("===== CREATE =====");

            operations.AddInstructor();
            operations.AddCourse();
            operations.AddSeveralStudents();
            operations.EnrollStudent();

            Console.WriteLine("\n===== READ =====");

            operations.FindCourse();
            operations.FilterCourses();
            operations.PrintCategories();
            operations.PrintCourseRoster();

            Console.WriteLine("\n===== UPDATE =====");

            operations.ChangePrice();
            operations.UpdateProgress();
            operations.PublishCourse();

            Console.WriteLine("\n===== DELETE =====");

            operations.UnenrollStudent();
            operations.TryDeleteCategory();
            operations.SafeDeleteCategory();
            operations.DeleteCourse();

            Console.WriteLine("\n===== BULK OPERATIONS =====");

            await operations.BulkPriceRaise();
            await operations.BulkDeleteDroppedEnrollments();

            Console.WriteLine("\nAll operations completed.");
        }
    }
}