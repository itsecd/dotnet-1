using ConsoleApp1.Commands;
using ConsoleApp1.Infrastructure;
using ConsoleApp1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XmlStorageRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<InsertFunctionCommand>("Insert");
                config.AddCommand<GetAllFunctionsCommand>("GetAllFunctions");
                config.AddCommand<RemoveAtFunctionCommand>("RemoveAt");
                config.AddCommand<ClearFunctionsCommand>("Clear");
                config.AddCommand<GetDerivativeFunctionCommand>("GetDerivative");
                config.AddCommand<ComputeFunctionCommand>("Compute");
                config.AddCommand<MinValueAllDerivativeCommand>("MinValueDerivative");
                config.AddCommand<ComparisonFunctionsCommand>("Comparison");
            });

            app.Run(args);
        }
    }
}