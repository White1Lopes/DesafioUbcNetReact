using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Services;
using DesafioUbc.Infrastructure.Data.Repositories;

namespace DesafioUbc.Api.Startup;

public static class IocConfiguration
{
    public static void AddIoc(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentMapper, StudentMapper>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}