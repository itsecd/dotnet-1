using Lab1.Commands;
using Lab1.Infrastructure.Lab1.Infrastructure;
using Lab1.Repository;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigureRepository, FigureRepository>();
            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("Add");
                config.AddCommand<ClearFiguresCommand>("Clear");
                config.AddCommand<CompareFiguresCommand>("Compare");
                config.AddCommand<RemoveFigureCommand>("Remove");
                config.AddCommand<PrintFiguresCommand>("Print");
                config.AddCommand<GetSumAreaCommand>("Sum");
            });
            app.Run(args);
            Console.ReadKey();
        }
    }
}