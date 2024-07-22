using DesafioUbc.Api.Controllers;
using DesafioUbc.Application.Requests.Student;
using DesafioUbc.Application.Responses;
using DesafioUbc.Application.Services;
using DesafioUbc.Business.Entitys;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioUbc.Api.Tests;

public class StudentControllerTests
{
    private readonly Mock<IStudentService> _mockStudentService;
    private readonly StudentController _studentController;

    public StudentControllerTests()
    {
        _mockStudentService = new Mock<IStudentService>();
        _studentController = new StudentController(_mockStudentService.Object);
    }

    [Fact]
    public void GetById_ShouldReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var expectedResponse = new Response<Student?>(expectedStudent);

        _mockStudentService.Setup(service => service.GetById(studentId)).Returns(expectedResponse);

        // Act
        var result = _studentController.GetById(studentId);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void GetById_ShouldReturnsNotFoundResult_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId       = 1L;
        var serviceResponse = new Response<Student?>(null);

        _mockStudentService.Setup(service => service.GetById(studentId)).Returns(serviceResponse);

        // Act
        var result = _studentController.GetById(studentId);

        // Assert
        var notFoundResult   = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student?>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }

    [Fact]
    public void Create_ShouldReturnsCreated()
    {
        //Arrange
        var studentRequest         = new EditorStudentRequest() { Nome = "Test" };
        var expectedStudent = new Student() { Nome = "Test" };
        var serviceResponse = new Response<Student?>(expectedStudent);

        _mockStudentService.Setup(service => service.Create(studentRequest)).Returns(serviceResponse);

        // Act
        var result = _studentController.Create(studentRequest);

        // Assert
        var createdResult    = Assert.IsType<CreatedResult>(result);
        var returnedResponse = Assert.IsType<Response<Student?>>(createdResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void GetAll_ShouldReturnsOkResult()
    {
        // Arrange
        var getAllRequest    = new GetAllStudentsRequest() { PageNumber = 1, PageSize = 25};
        var expectedList     = new List<Student> { new () { Id = 1 } };
        var expectedResponse = new PagedResponse<List<Student>>(expectedList, 1, 1, 25);

        _mockStudentService.Setup(service =>
                               service.GetAll(It.Is<GetAllStudentsRequest>(r => r.PageNumber == 1 && r.PageSize == 25)))
                           .Returns(expectedResponse);


        // Act
        var result = _studentController.GetAll(getAllRequest.PageNumber, getAllRequest.PageSize);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<PagedResponse<List<Student>>>(okResult.Value);
        Assert.Equal(expectedList, returnedResponse.Data);
    }

    [Fact]
    public void UpdateStudent_ShouldReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var updatedRequest   = new EditorStudentRequest() { Nome = "Test" };
        var expectedResponse = new Response<Student?>(expectedStudent);

        _mockStudentService.Setup(service => service.Update(studentId, updatedRequest)).Returns(expectedResponse);

        // Act
        var result = _studentController.Update(studentId, updatedRequest);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void UpdateStudent_ShouldReturnsNotFoundResult_WhenStudentDoesNotExists()
    {
        // Arrange
        var studentId        = 1L;
        var updatedRequest   = new EditorStudentRequest() { Nome = "Test" };
        var expectedResponse = new Response<Student?>(null);

        _mockStudentService.Setup(service => service.Update(studentId, updatedRequest)).Returns(expectedResponse);

        // Act
        var result = _studentController.Update(studentId, updatedRequest);

        // Assert
        var notFoundResult        = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }

    [Fact]
    public void DeleteStudent_ShouldReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var expectedResponse = new Response<Student?>(expectedStudent);

        _mockStudentService.Setup(service => service.Delete(studentId)).Returns(expectedResponse);

        // Act
        var result = _studentController.Delete(studentId);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void DeleteStudent_ShouldReturnsNotFoundResult_WhenStudentDoesNotExists()
    {
        // Arrange
        var studentId        = 1L;
        var expectedResponse = new Response<Student?>(null);

        _mockStudentService.Setup(service => service.Delete(studentId)).Returns(expectedResponse);

        // Act
        var result = _studentController.Delete(studentId);

        // Assert
        var notFoundResult   = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }
}