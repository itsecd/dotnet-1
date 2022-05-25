using Microsoft.Extensions.DependencyInjection;
using PromProgLab1.Commands;
using PromProgLab1.Infrastructure;
using PromProgLab1.Repositories;
using Spectre.Console.Cli;

namespace PromProgLab1
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
                config.AddCommand<RemoveAtCommand>("delete");
                config.AddCommand<RemoveCollectionsCommand>("clear");
                config.AddCommand<FindMinOperationCommand>("min");
                config.AddCommand<ComparingOperationsCommand>("compare");
            });
            app.Run(args);
        }
    }
}
