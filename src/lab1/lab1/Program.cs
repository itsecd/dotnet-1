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
            serviceCollection.AddSingleton<IBinaryOperationsRepository, XmlBinaryOperationsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddBinaryOperation>("add");
                config.AddCommand<RemoveBinaryOperation>("remove");
                config.AddCommand<ShowAllBinaryOperation>("show");
                config.AddCommand<CompareBinaryOperation>("compare");
                config.AddCommand<MinBinaryOperation>("min");
            });

            app.Run(args);
        }
    }
}
