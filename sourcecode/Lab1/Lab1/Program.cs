using Lab1.Commands;
using Lab1.Infrastructure.Lab1.Infrastructure;
using Lab1.Reposity;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigureRepository, FigureRepository>();
            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);
            app.Configure(config => 
            {
                config.AddCommand<FigureCommands>("Add");
                config.AddCommand<ClearAllFigure>("Clear");
                config.AddCommand<CompareTwoFigure>("Compare");
                config.AddCommand<RemoveFigure>("Remove");
                config.AddCommand<PrintListFigure>("Print");
            });
            app.Run(args);
        }      
    }
}
