using System;
using System.IO;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "DEV";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<Service>();
            services.AddSingleton<CosmosDbContextOne>();
            services.AddSingleton<CosmosDbContextTwo>();
            services.AddSingleton<ICosmosRepository, CosmosRepository>();
            services.Configure<Settings>(configuration.GetSection(nameof(Settings)));
            services.AddSingleton<AbstractCosmosDbContext>(provider =>
            {
                var settings = provider.GetService<IOptions<Settings>>().Value;
                return settings.DbContextName switch
                {
                    nameof(CosmosDbContextOne) => provider.GetService<CosmosDbContextOne>(),
                    nameof(CosmosDbContextTwo) => provider.GetService<CosmosDbContextTwo>(),
                    _ => throw new ArgumentOutOfRangeException(settings.DbContextName)
                };
            });
            services.AddDbContext<AbstractCosmosDbContext>((provider, builder) =>
            {
                var settings = provider.GetService<IOptions<Settings>>().Value;
                builder.UseCosmos(settings.EndpointUrl, settings.AuthorizationKey, settings.DatabaseName);
            });

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<Service>();
            await service.PrintAuthorsAsync();

            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
