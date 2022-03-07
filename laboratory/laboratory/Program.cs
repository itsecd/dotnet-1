using laboratory.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using laboratory.Command;

namespace laboratory
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Command
            var serviseCollection = new ServiceCollection();

            serviseCollection.AddSingleton<IRepository, XmlFigureRepository>();

            var registr = new TypeRegistrar(serviseCollection);
            var app = new CommandApp(registr);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<PrintFigureCommand>("print");
                config.AddCommand<RemoveFigureCommand>("remuve");
                config.AddCommand<ComparisonFigureCommand>("comparison");
                config.AddCommand<FramingRectangleFigureCommand>("framingrectang");
                config.AddCommand<PerimeterFigureCommand>("perimeter");
                config.AddCommand<SquareFigureCommand>("squeare");
                config.AddCommand<TotalAreaFigureCommand>("totalarea");

            });
            app.Run(args);
        }
    }
}
