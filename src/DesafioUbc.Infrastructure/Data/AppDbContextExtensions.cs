using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioUbc.Infrastructure.Data;

public static class AppDbContextExtensions
{
    public static void AddApplicationDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(o => { o.UseInMemoryDatabase("UBC"); });
    }
}