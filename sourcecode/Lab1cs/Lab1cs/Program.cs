using Lab1cs.Commands;
using Lab1cs.Infrastructure.Lab1.Infrastructure;
using Lab1cs.Reposity;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1cs
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
