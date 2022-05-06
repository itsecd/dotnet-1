using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Lab1.Commands;
using Lab1.infrastructure;
using lab1.services.interfaces;
using lab1.services.interfaces.impl;
using Lab1.Сommands;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionRepo, XMLFuncDAO>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<InsertFunctionCommand>("insert");
                config.AddCommand<DeleteFunctionCommand>("delete");
                config.AddCommand<DeleteAllFunctionCommand>("deleteall");
                config.AddCommand<CompareFunctionCommand>("compare");
            });

            app.Run(args);

        }
    }
}