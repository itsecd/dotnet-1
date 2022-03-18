using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

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
                config.AddCommand<AddCommand>("add");
                config.AddCommand<OutputCommand>("output");
                config.AddCommand<RemoveAtCommand>("remove_at");
                config.AddCommand<RemoveAllCommand>("remove_all");
                config.AddCommand<CompareCommand>("compare");
            });
            app.Run(args);
        }
    }
}
