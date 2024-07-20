using DesafioUbc.Api.Helper;
using DesafioUbc.Infrastructure.Data;

namespace DesafioUbc.Api.Startup;

public static class SeedDb
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            var students = CsvSeeder.GetStudentsFromCsv("Seed/studentsSeed.csv");

            var id = 1;
            foreach (var student in students)
            {
                student.Id = id++;
            }

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}