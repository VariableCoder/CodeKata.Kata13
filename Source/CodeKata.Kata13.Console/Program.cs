using CodeKata.Kata13.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CodeKata.Kata13.Console
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            RunProgram(host.Services);

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<ITestRunnerService, TestRunnerService>()
                            .AddScoped<ILineCountingService, LineCountingService>());

        static void RunProgram(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            ITestRunnerService testService = provider.GetRequiredService<ITestRunnerService>();

            var inputTestScenario = testService.GetUsersInputTestScenario();

            var numberOfLines = testService.RunTestScenario(inputTestScenario);

            System.Console.WriteLine($"Number of lines : {numberOfLines}");
        }
    }
}
