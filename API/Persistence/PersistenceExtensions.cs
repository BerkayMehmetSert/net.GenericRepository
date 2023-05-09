using API.Application.Repositories;
using API.Persistence.Context;
using API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public static class PersistenceExtensions
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
