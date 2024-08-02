using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postgres.Application.Context;

namespace Postgres.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgresApplication(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<PostgresContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
