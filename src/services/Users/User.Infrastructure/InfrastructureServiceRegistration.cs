using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts.Persistence;
using User.Infrastructure.Persistence.Context;
using User.Infrastructure.Repositories;

namespace User.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Infra Data Layer
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserConnectionString"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();

            return services;
        }
    }
}
