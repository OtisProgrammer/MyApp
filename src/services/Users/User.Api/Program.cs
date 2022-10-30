using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using User.Api.Extensions;
using User.Infrastructure.Persistence.Context;
using User.Infrastructure.Persistence.ContextSeed;

namespace User.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<UserContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<UserContextSeed>>();
                    UserContextSeed.SeedAsync(context, logger).Wait();
                })
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
