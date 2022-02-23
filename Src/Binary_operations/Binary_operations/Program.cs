using Binary_operations.Commands;
using Binary_operations.Repositories;
using Lab1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Binary_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IOperationRepository, XmlOperationRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddOperationCommand>("add");
                config.AddCommand<GetAllOperationsCommand>("print");
                config.AddCommand<RemoveOperationCommand>("delete");
                config.AddCommand<RemoveAllCollection>("clear");
                config.AddCommand<MinOperation>("min");
                config.AddCommand<ComparingOperationsCommand>("compare");
            });
            app.Run(args);

            IOperationRepository operations_repository = new XmlOperationRepository();


        }
    }
}
