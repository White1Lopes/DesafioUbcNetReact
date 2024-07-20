using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Requests.User;
using DesafioUbc.Application.Responses;
using DesafioUbc.Application.Responses.User;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DesafioUbc.Application.Services;

public interface IUserService
{
    Response<TokenResponse?> Login(LoginRequest user, string authKey);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public UserService(IUserRepository userRepository, IUserMapper userMapper)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public Response<TokenResponse?> Login(LoginRequest request, string authKey)
    {
        var user = _userRepository.GetByUsername(request.Username);

        if (user is null)
            return new Response<TokenResponse?>(null, false, "Email ou senha inválidos!");

        if (user.Password != request.Password)
            return new Response<TokenResponse?>(null, false, "Email ou senha inválidos!");

        return new Response<TokenResponse?>(BuildToken(user, authKey), true, "Usuário logado com sucesso!");
    }


    private static TokenResponse BuildToken(User user, string authKey)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddHours(2);

        JwtSecurityToken token = new(issuer: null, audience: null, claims: claims, expires: expiration,
            signingCredentials: creds);

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}