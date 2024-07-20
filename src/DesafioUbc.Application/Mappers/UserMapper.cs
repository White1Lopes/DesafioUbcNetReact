using DesafioUbc.Application.Requests.User;
using DesafioUbc.Business.Entitys;

namespace DesafioUbc.Application.Mappers;

public interface IUserMapper
{
    User RequestToDomain(LoginRequest request);
}

public class UserMapper : IUserMapper
{
    public User RequestToDomain(LoginRequest request)
    {
        return new User()
        {
            Username = request.Username,
            Password = request.Password
        };
    }
}