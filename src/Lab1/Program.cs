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
            serviceCollection.AddSingleton<IOperationsRepository, XmlOperationsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddOperationCommand>("add");
                config.AddCommand<GetAllOperationsCommand>("print");
                config.AddCommand<MinOperationCommand>("min operation");
                config.AddCommand<RemoveOperationCommand>("remove operation");
                config.AddCommand<RemoveCollectionCommand>("remove all");
            });

            app.Run(args);
        }
    }
}
