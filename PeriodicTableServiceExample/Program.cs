using System;
using Microsoft.Extensions.DependencyInjection;
using PeriodicTableService;

namespace PeriodicTableServiceExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(async (services) => await Peridtio)
        }
    }
}
