using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data;
using DesafioUbc.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Tests;

public class StudentRepositoryTests
{
    private readonly StudentRepository _repository;

    public StudentRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                      .UseInMemoryDatabase(databaseName: "Test")
                      .Options;

        var context = new AppDbContext(options);
        _repository = new StudentRepository(context);
    }

    [Fact]
    public void Add_ShouldAddStudent()
    {
        // Arrange
        var student = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};

        // Act
        var addedStudent = _repository.Add(student);

        // Assert
        Assert.NotNull(addedStudent);
        Assert.NotEqual(0, addedStudent.Id);
    }

    [Fact]
    public void Get_ShouldReturnStudentById()
    {
        // Arrange
        var student = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};
        _repository.Add(student);

        // Act
        var retrievedStudent = _repository.Get(student.Id);

        // Assert
        Assert.NotNull(retrievedStudent);
        Assert.Equal(student.Id, retrievedStudent.Id);
    }

    [Fact]
    public void GetAll_ShouldReturnAllStudents()
    {
        // Arrange
        var student1 = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};
        var student2 = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};
        _repository.Add(student1);
        _repository.Add(student2);

        // Act
        var (students,count) = _repository.GetAll(1, 25);

        // Assert
        Assert.NotInRange(count, 0, 1);
    }

    [Fact]
    public void Update_ShouldUpdateStudent()
    {
        // Arrange
        var student = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};
        _repository.Add(student);
        student.Nome = "Updated";

        // Act
        var updatedStudent = _repository.Update(student);

        // Assert
        Assert.NotNull(updatedStudent);
        Assert.Equal("Updated", updatedStudent.Nome);
    }

    [Fact]
    public void Delete_ShouldRemoveStudent()
    {
        // Arrange
        var student = new Student { Nome = "Test", Endereco = "Test", NomeMae = "Test", NomePai = "Test"};
        _repository.Add(student);

        // Act
        _repository.Delete(student);
        var retrievedStudent = _repository.Get(student.Id);

        // Assert
        Assert.Null(retrievedStudent);
    }
}