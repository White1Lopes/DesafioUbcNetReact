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
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IConfiguration> _mockConfiguration;
    private readonly UserController _userController;

    public UserControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _mockConfiguration = new Mock<IConfiguration>();
        _userController = new UserController(_mockUserService.Object, _mockConfiguration.Object);
    }

    [Fact]
    public void Login_ShouldReturnsOkResult_WhenLoginIsSuccessful()
    {
        // Arrange
        var loginRequest      = new LoginRequest { Username = "test", Password = "password" };
        var expectedResponse  = new Response<TokenResponse?> (new TokenResponse() { Token = "test"});

        _mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("some_secret_key");
        _mockUserService.Setup(service => service.Login(loginRequest, "some_secret_key")).Returns(expectedResponse);

        // Act
        var result = _userController.Login(loginRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<TokenResponse>>(okResult.Value);
        Assert.Equal(expectedResponse, returnedResponse);
    }

    [Fact]
    public void Login_ShouldReturnsBadRequest_WhenLoginFails()
    {
        // Arrange
        var loginRequest = new LoginRequest { Username = "test", Password = "wrong_password" };
        var expectedResponse = new Response<TokenResponse>(null);

        _mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("some_secret_key");
        _mockUserService.Setup(service => service.Login(loginRequest, "some_secret_key")).Returns(expectedResponse);

        // Act
        var result = _userController.Login(loginRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var returnedResponse = Assert.IsType<Response<TokenResponse>>(badRequestResult.Value);
        Assert.Null(returnedResponse.Data);
    }
}