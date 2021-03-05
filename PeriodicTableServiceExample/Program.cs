using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Periodic.Models;
using Periodic.Services;

namespace PeriodicTableServiceExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new Program().MainAsync();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services
            .AddSingleton<HttpClient>()
            .AddSingleton<PeriodicTableService>();
        }
        public async Task MainAsync()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            var periodicTableService = provider.GetRequiredService<PeriodicTableService>();
            var periodicTable = await periodicTableService.GetPeriodicTableAsync();
            //var periodicTable = await periodicTableService.GetPeriodicTableAsync(false);

            Console.WriteLine(periodicTable.Elements[0]);

            if (periodicTable is IndexedPeriodicTable indexed)
            {
                indexed.TryGetElementByName("Iron", out var iron);
                Console.WriteLine(iron);
                indexed.TryGetElementBySymbol("ag", out var silver);
                Console.WriteLine(silver);
            }



        }
    }
}
