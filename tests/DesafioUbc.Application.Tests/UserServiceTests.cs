using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Requests.User;
using DesafioUbc.Application.Responses;
using DesafioUbc.Application.Responses.User;
using DesafioUbc.Application.Services;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Repositories;
using Moq;

namespace DesafioUbc.Application.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserMapper> _mockUserMapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserService UserService;
    const string authKey = "some-secret-keyyyyyyyyyyyyyyyyyyyyyyyyyyyy";

    public UserServiceTests()
    {
        _mockUserMapper = new Mock<IUserMapper>();
        _mockUserRepository = new Mock<IUserRepository>();
        UserService = new UserService(_mockUserRepository.Object, _mockUserMapper.Object);
    }

    [Fact]
    public void Login_ReturnsToken_WhenSuccess()
    {
        //Arrange
        var request      = new LoginRequest() { Username = "test", Password = "test" };
        var expectedUser = new User() { Username = "test", Password = "test" };

        _mockUserRepository.Setup(r => r.GetByUsername(expectedUser.Username)).Returns(expectedUser);

        // Act

        var result = UserService.Login(request, authKey);

        // Arrange

        Assert.NotNull(result.Data);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Login_ReturnsNull_WhenFailure()
    {
        //Arrange
        var request      = new LoginRequest() { Username = "test", Password = "test" };
        var expectedUser = new User() { Username = "test", Password = "test" };

        _mockUserRepository.Setup(r => r.GetByUsername(expectedUser.Username)).Returns((User)null);

        // Act

        var result = UserService.Login(request, authKey);

        // Arrange

        Assert.Null(result.Data);
        Assert.False(result.IsValid);
    }
}