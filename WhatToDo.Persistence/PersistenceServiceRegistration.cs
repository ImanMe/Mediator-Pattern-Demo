using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatToDo.Core.Contracts;

namespace WhatToDo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddIPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WhatToDoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WhatToDoConnection")));

            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
