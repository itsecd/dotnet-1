using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Lab1_3D.Commands;
using Lab1.Infrastructure;
using Lab1_3D.Repositories;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigures, XmlFigures3DRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigure>("Add");
                config.AddCommand<PrintAllFigure>("Print");
                config.AddCommand<DeleteFigure>("Delete");
                config.AddCommand<DeleteAllFigures>("DeleteAll");
                config.AddCommand<CompareFigures>("Compare");
                config.AddCommand<TotalVolumeCollection>("VolumeAll");
            });
            app.Run(args);
        }
    }
}
