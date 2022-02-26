using iProg1.Commands;
using iProg1.Repositories;
using Lab1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

namespace iProg1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMatrixRepository, XmlMatrixRepository>();
            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
                config.AddCommand<AddMatrixCommand>("add")
                    .WithDescription("Creating a matrix.");
                config.AddCommand<RemoveMatrixCommand>("remove")
                    .WithDescription("Remove a matrix.");
                config.AddCommand<RemoveAllMatrixCommand>("removeAll")
                    .WithDescription("Remove all matrix.");
                config.AddCommand<CompareMatrixCommand>("compare")
                    .WithDescription("Comparison of two matrices.");
                config.AddCommand<EditMatrixCommand>("edit")
                    .WithDescription("Editing a matrix element.");
                config.AddCommand<OutputAllMatrixCommand>("output")
                    .WithDescription("Print matrices.");
                config.AddCommand<PrintMinMaxAbsMatrixCommand>("minMax")
                    .WithDescription("Determination of the matrix with the lowest norm of the maximum of the module.");
            });
            int result = app.Run(args);
            if (result == 1)
            {
                AnsiConsole.Write(new FigletText("Done")
                    .LeftAligned()
                    .Color(Color.Green));
            }
            if(result == -1)
            {
                AnsiConsole.Write(new FigletText("Failed")
                    .LeftAligned()
                    .Color(Color.Red));
            }
            if(result == -10)
            {
                AnsiConsole.Write(new FigletText("Stopped")
                    .LeftAligned()
                    .Color(Color.Yellow));
            }
        }
    }
}
