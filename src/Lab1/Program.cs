using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Repository;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

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
                config.AddCommand<InsertCommand>("insert");
                config.AddCommand<GetAllCommand>("print");
                config.AddCommand<CompareCommand>("compare");
                config.AddCommand<MinCommand>("min");
                config.AddCommand<RemoveAtCommand>("remove operation");
                config.AddCommand<ClearCommand>("clear");
            });

            app.Run(args);
        }
    }
}
