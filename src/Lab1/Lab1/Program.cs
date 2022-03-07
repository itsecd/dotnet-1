using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Lab1.Commands;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XmlFunctionsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<PrintFunctionsCommand>("print");
                config.AddCommand<ComparisonFunctionsCommand>("comparison");
                config.AddCommand<InsertFunctionCommand>("insert");
                config.AddCommand<RemoveFunctionCommand>("remove");
                config.AddCommand<RemoveAllFunctionsCommand>("remove_all");
                config.AddCommand<MaxFunctionCommand>("max_function");
            });

            app.Run(args);
        }
    }
}
