using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data;
using DesafioUbc.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Tests;

public class UserRepositoryTests
{
    private readonly UserRepository _repository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                      .UseInMemoryDatabase(databaseName: "Test")
                      .Options;

        var context = new AppDbContext(options);
        _repository = new UserRepository(context);
    }

    [Fact]
    public void Add_ShouldAddUser()
    {
        // Arrange
        var user = new User { Username = "Test", Password = "Test"};

        // Act
        var addedUser = _repository.Add(user);

        // Assert
        Assert.NotNull(addedUser);
        Assert.NotEqual(0, addedUser.Id);
    }

    [Fact]
    public void Get_ShouldReturnUserById()
    {
        // Arrange
        var user = new User { Username = "Test", Password = "Test"};
        _repository.Add(user);

        // Act
        var retrievedUser = _repository.Get(user.Id);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(user.Id, user.Id);
    }

    [Fact]
    public void GetByUsername_ShouldReturnUser()
    {
        // Arrange
        var user = new User { Username = "Test Name", Password = "Test"};
        _repository.Add(user);

        // Act
        var retrievedUser = _repository.GetByUsername(user.Username);

        // Assert
        Assert.Equal(user, retrievedUser);
    }

    [Fact]
    public void Update_ShouldUpdateStudent()
    {
        // Arrange
        var user = new User { Username = "Test", Password = "Test"};
        _repository.Add(user);
        user.Username = "Updated";

        // Act
        var updatedUser = _repository.Update(user);

        // Assert
        Assert.NotNull(updatedUser);
        Assert.Equal("Updated", updatedUser.Username);
    }

    [Fact]
    public void Delete_ShouldRemoveStudent()
    {
        // Arrange
        var user = new User { Username = "Test", Password = "Test"};
        _repository.Add(user);

        // Act
        _repository.Delete(user);
        var retrievedUser = _repository.Get(user.Id);

        // Assert
        Assert.Null(retrievedUser);
    }
}