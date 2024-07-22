using DesafioUbc.Api.Controllers;
using DesafioUbc.Application.Requests.User;
using DesafioUbc.Application.Responses;
using DesafioUbc.Application.Responses.User;
using DesafioUbc.Application.Services;
using DesafioUbc.Business.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace DesafioUbc.Api.Tests;

public class UserControllerTests
{
    [Fact]
    public void Login_ReturnsOkResult_WhenLoginIsSuccessful()
    {
        // Arrange
        var mockService       = new Mock<IUserService>();
        var mockConfiguration = new Mock<IConfiguration>();
        var loginRequest      = new LoginRequest { Username = "test", Password = "password" };
        var expectedResponse  = new Response<TokenResponse?> (new TokenResponse() { Token = "test"});

        mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("some_secret_key");
        mockService.Setup(service => service.Login(loginRequest, "some_secret_key")).Returns(expectedResponse);

        var controller = new UserController(mockService.Object, mockConfiguration.Object);

        // Act
        var result = controller.Login(loginRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<TokenResponse>>(okResult.Value);
        Assert.Equal(expectedResponse, returnedResponse);
    }

    [Fact]
    public void Login_ReturnsBadRequest_WhenLoginFails()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var mockConfiguration = new Mock<IConfiguration>();
        var loginRequest = new LoginRequest { Username = "test", Password = "wrong_password" };
        var expectedResponse = new Response<TokenResponse>(null);

        mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("some_secret_key");
        mockService.Setup(service => service.Login(loginRequest, "some_secret_key")).Returns(expectedResponse);

        var controller = new UserController(mockService.Object, mockConfiguration.Object);

        // Act
        var result = controller.Login(loginRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<TokenResponse>>(badRequestResult.Value);
        Assert.Null(returnedResponse.Data);
    }
}