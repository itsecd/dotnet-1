using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1
{
    public class main
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFiguresRepository, XmlFiguresRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("Add");
                config.AddCommand<DeleteFigureCommand>("Delete");
                config.AddCommand<DeleteAllFigureCommand>("DeleteAll");
                config.AddCommand<CompareFigureCommand>("Compare");
                config.AddCommand<ViewTableCommand>("ViewTable");
                config.AddCommand<SumFigureCommand>("Sum");

            });
            
            app.Run(args);
        }
    }
}
