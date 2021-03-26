using System.Collections.Generic;
using Force.Cqrs;
using Force.Ddd.DomainEvents;
using Infrastructure.Ddd;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IHandler<IEnumerable<ProductPurchased>>, OrderDomainEventHandler>();
                    services.AddSingleton<IHandler<IEnumerable<IDomainEvent>>, DomainEventDispatcher>();
                    services.AddHostedService<Worker>();
                });
    }
}