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
    [Fact]
    public void GetById_ReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var expectedResponse = new Response<Student?>(expectedStudent);

        mockService.Setup(service => service.GetById(studentId)).Returns(expectedResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.GetById(studentId);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void GetById_ReturnsNotFoundResult_WhenStudentDoesNotExist()
    {
        // Arrange
        var mockService     = new Mock<IStudentService>();
        var studentId       = 1L;
        var serviceResponse = new Response<Student?>(null);

        mockService.Setup(service => service.GetById(studentId)).Returns(serviceResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.GetById(studentId);

        // Assert
        var notFoundResult   = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student?>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }

    [Fact]
    public void Create_ReturnsCreated()
    {
        //Arrange
        var mockService     = new Mock<IStudentService>();
        var studentRequest         = new EditorStudentRequest() { Nome = "Test" };
        var expectedStudent = new Student() { Nome = "Test" };
        var serviceResponse = new Response<Student?>(expectedStudent);

        mockService.Setup(service => service.Create(studentRequest)).Returns(serviceResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.Create(studentRequest);

        // Assert
        var createdResult    = Assert.IsType<CreatedResult>(result);
        var returnedResponse = Assert.IsType<Response<Student?>>(createdResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void GetAll_ReturnsOkResult()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var getAllRequest    = new GetAllStudentsRequest() { PageNumber = 1, PageSize = 25};
        var expectedList     = new List<Student> { new () { Id = 1 } };
        var expectedResponse = new PagedResponse<List<Student>>(expectedList, 1, 1, 25);

        mockService.Setup(service =>
                       service.GetAll(It.Is<GetAllStudentsRequest>(r => r.PageNumber == 1 && r.PageSize == 25)))
                   .Returns(expectedResponse);


        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.GetAll(getAllRequest.PageNumber, getAllRequest.PageSize);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<PagedResponse<List<Student>>>(okResult.Value);
        Assert.Equal(expectedList, returnedResponse.Data);
    }

    [Fact]
    public void UpdateStudent_ReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var updatedRequest   = new EditorStudentRequest() { Nome = "Test" };
        var expectedResponse = new Response<Student?>(expectedStudent);

        mockService.Setup(service => service.Update(studentId, updatedRequest)).Returns(expectedResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.Update(studentId, updatedRequest);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void UpdateStudent_ReturnsNotFoundResult_WhenStudentDoesNotExists()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var studentId        = 1L;
        var updatedRequest   = new EditorStudentRequest() { Nome = "Test" };
        var expectedResponse = new Response<Student?>(null);

        mockService.Setup(service => service.Update(studentId, updatedRequest)).Returns(expectedResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.Update(studentId, updatedRequest);

        // Assert
        var notFoundResult        = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }

    [Fact]
    public void DeleteStudent_ReturnsOkResult_WhenStudentExists()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var studentId        = 1L;
        var expectedStudent  = new Student { Id = studentId };
        var expectedResponse = new Response<Student?>(expectedStudent);

        mockService.Setup(service => service.Delete(studentId)).Returns(expectedResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.Delete(studentId);

        // Assert
        var okResult         = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(okResult.Value);
        Assert.Equal(expectedStudent, returnedResponse.Data);
    }

    [Fact]
    public void DeleteStudent_ReturnsNotFoundResult_WhenStudentDoesNotExists()
    {
        // Arrange
        var mockService      = new Mock<IStudentService>();
        var studentId        = 1L;
        var expectedResponse = new Response<Student?>(null);

        mockService.Setup(service => service.Delete(studentId)).Returns(expectedResponse);

        var controller = new StudentController(mockService.Object);

        // Act
        var result = controller.Delete(studentId);

        // Assert
        var notFoundResult   = Assert.IsType<NotFoundObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<Student>>(notFoundResult.Value);
        Assert.Null(returnedResponse.Data);
    }
}