using System.Threading.Tasks;
using Infrastructure.Rabbit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerServices
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostWorker = CreateHostBuilderWorker(args).Build();
            await hostWorker.InitAsync();
            await hostWorker.RunAsync();
        }
        public static IHostBuilder CreateHostBuilderWorker(string[] args) =>
            Host
            .CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            })
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
            });
    }
}