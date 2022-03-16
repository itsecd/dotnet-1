using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFiguresRepository, FiguresRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("Add");
                config.AddCommand<CompareFiguresCommand>("Compare");
                config.AddCommand<PrintAllFiguresCommand>("Print");
                config.AddCommand<RemoveFigureCommand>("Remove");
                config.AddCommand<RemoveAllFigureCommand>("RemoveAll");
                config.AddCommand<GetMinRectangleCommand>("MinRectangle");
                config.AddCommand<SumAreaCollectionCommand>("VolumeAll");
            });
            app.Run(args);

        }
    }
}
