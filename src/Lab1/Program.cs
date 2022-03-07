using Lab1.Repository;
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
            serviceCollection.AddSingleton<IOperationRepository, XmlOperationRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddOperationCommand>("insert");
                config.AddCommand<GetAllOperationsCommand>("print");
                config.AddCommand<MinOperationCommand>("min");
                config.AddCommand<RemoveOperationCommand>("remove operation");
                config.AddCommand<RemoveCollectionCommand>("clear");
            });

            app.Run(args);
        }
    }
}
