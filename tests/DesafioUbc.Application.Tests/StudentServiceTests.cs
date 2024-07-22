using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Requests.Student;
using DesafioUbc.Application.Services;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Repositories;
using Moq;

namespace DesafioUbc.Application.Tests;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _mockStudentRepository;
    private readonly Mock<IStudentMapper> _mockStudentMapper;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _mockStudentRepository = new Mock<IStudentRepository>();
        _mockStudentMapper = new Mock<IStudentMapper>();
        _studentService = new StudentService(_mockStudentRepository.Object, _mockStudentMapper.Object);
    }

    [Fact]
    public void Create_ShouldReturnResponseWithStudent()
    {
        // Arrange
        var request = new EditorStudentRequest { Nome = "Test" };
        var student = new Student { Id = 1, Nome = "Test" };

        _mockStudentMapper.Setup(mapper => mapper.RequestToDomain(request)).Returns(student);
        _mockStudentRepository.Setup(repo => repo.Add(student)).Returns(student);

        // Act
        var response = _studentService.Create(request);

        // Assert
        Assert.True(response.IsValid);
        Assert.NotNull(response.Data);
        Assert.Equal(student, response.Data);
    }

    [Fact]
    public void GetAll_ShouldReturnPagedResponseWithStudents()
    {
        // Arrange
        var request  = new GetAllStudentsRequest { PageNumber = 1, PageSize = 10 };
        var students = new List<Student> { new() { Id = 1, Nome = "Student 1" } };
        int count    = 1;

        _mockStudentRepository.Setup(repo => repo.GetAll(request.PageNumber, request.PageSize)).Returns((students, count));

        // Act
        var response = _studentService.GetAll(request);

        // Assert
        Assert.True(response.IsValid);
        Assert.Equal(students, response.Data);
        Assert.Equal(count, response.TotalCount);
        Assert.Equal(request.PageNumber, response.CurrentPage);
        Assert.Equal(request.PageSize, response.PageSize);
    }

    [Fact]
    public void GetById_ShouldReturnResponseWithStudent()
    {
        // Arrange
        long studentId = 1;
        var  student   = new Student { Id = studentId, Nome = "Student 1" };

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(student);

        // Act
        var response = _studentService.GetById(studentId);

        // Assert
        Assert.True(response.IsValid);
        Assert.NotNull(response.Data);
        Assert.Equal(student, response.Data);
    }

    [Fact]
    public void GetById_ShouldReturnResponseWithNull_WhenStudentNotFound()
    {
        // Arrange
        long studentId = 1;

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns((Student)null);

        // Act
        var response = _studentService.GetById(studentId);

        // Assert
        Assert.False(response.IsValid);
        Assert.Null(response.Data);
    }

    [Fact]
    public void Update_ShouldReturnResponseWithUpdatedStudent()
    {
        // Arrange
        long studentId      = 1;
        var  request        = new EditorStudentRequest { Nome = "Updated" };
        var  student        = new Student { Id = studentId, Nome =  "Existing" };
        var  updatedStudent = new Student { Id = studentId, Nome = "Updated" };

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(student);
        _mockStudentMapper.Setup(mapper => mapper.RequestToDomain(request)).Returns(updatedStudent);
        _mockStudentRepository.Setup(repo => repo.Update(updatedStudent)).Returns(updatedStudent);

        // Act
        var response = _studentService.Update(studentId, request);

        // Assert
        Assert.True(response.IsValid);
        Assert.NotNull(response.Data);
        Assert.Equal(updatedStudent, response.Data);
    }

    [Fact]
    public void Update_ShouldReturnResponseWithNull_WhenStudentNotFound()
    {
        // Arrange
        long studentId = 1;
        var  request   = new EditorStudentRequest { Nome = "Updated Student" };

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns((Student)null);

        // Act
        var response = _studentService.Update(studentId, request);

        // Assert
        Assert.False(response.IsValid);
        Assert.Null(response.Data);
    }

    [Fact]
    public void Delete_ShouldReturnResponseWithDeletedStudent()
    {
        // Arrange
        long studentId = 1;
        var  student   = new Student { Id = studentId, Nome = "Student 1" };

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(student);
        _mockStudentRepository.Setup(repo => repo.Delete(student));

        // Act
        var response = _studentService.Delete(studentId);

        // Assert
        Assert.True(response.IsValid);
        Assert.NotNull(response.Data);
        Assert.Equal(student, response.Data);
    }

    [Fact]
    public void Delete_ShouldReturnResponseWithNull_WhenStudentNotFound()
    {
        // Arrange
        long studentId = 1;

        _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns((Student)null);

        // Act
        var response = _studentService.Delete(studentId);

        // Assert
        Assert.False(response.IsValid);
        Assert.Null(response.Data);
    }
}