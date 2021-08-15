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

            System.Console.WriteLine("Please enter a number corresponding to the desired test scenario to run.");
            System.Console.WriteLine($"The number entered should vary between 1 and {testService.GetNumberOfTestScenarios()}");

            var testScenarioString = System.Console.ReadLine();
            var testScenario = int.Parse(testScenarioString);

            var numberOfLines = testService.RunTestScenario(testScenario);

            System.Console.WriteLine($"Number of lines : {numberOfLines}");
        }
    }
}
