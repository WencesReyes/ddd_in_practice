using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DddInPracticeContext>(options => options.UseSqlServer(connectionString), optionsLifetime: ServiceLifetime.Singleton);

            return services;
        }
    }
}
