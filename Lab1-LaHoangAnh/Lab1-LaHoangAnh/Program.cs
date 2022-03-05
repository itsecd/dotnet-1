using System.Collections.Generic;
using Lab1.Mode;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Lab1.Commands;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigureRepository, XmlFigureRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<OutputCommand>("output");
                config.AddCommand<RemoveFigureCommand>("remove_one");
                config.AddCommand<RemoveAllCommand>("remove_all");
                config.AddCommand<CompareCommand>("compare");
            });
            app.Run(args);
        }
    }
}
