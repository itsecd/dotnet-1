using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Services.Interfaces;
using Lab1.Services.Interfaces.Impl;
using Lab1.Сommands;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionRepo, XMLFunctionRepo>();
            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<InsertFunctionCommand>("insert");
                config.AddCommand<DeleteFunctionCommand>("delete");
                config.AddCommand<DeleteAllFunctionCommand>("deleteall");
                config.AddCommand<ShowAllFunctionsCommand>("show");
            });
            app.Run(args);
        }
    }
}