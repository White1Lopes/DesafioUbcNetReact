using System.Globalization;
using CsvHelper;
using DesafioUbc.Business.Entitys;

namespace DesafioUbc.Api.Helper;

public static class CsvSeeder
{
    public static List<Student> GetStudentsFromCsv(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv    = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<StudentMap>();
        var students = csv.GetRecords<Student>().ToList();
        return students;
    }
}