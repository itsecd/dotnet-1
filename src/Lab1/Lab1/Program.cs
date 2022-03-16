using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Repository;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFiguresRepository, XmlFiguresRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<PrintFiguresCommand>("print");
                config.AddCommand<CompareFiguresCommand>("compare");
                config.AddCommand<GetTotalAreaCommand>("sum");
                config.AddCommand<RemoveFigureCommand>("remove");
                config.AddCommand<DeleteFiguresCommand>("clear");
            });

            app.Run(args);
        }
    }
}
