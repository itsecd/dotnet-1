using Lab1.FunctionsRepository;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Lab1.Commands;
using Spectre.Console.Cli;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XMLFunctionsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<ClearFunctionCommand>("clear");
                config.AddCommand<CompareFunctionCommand>("compare");
                config.AddCommand<CountFunctionCommand>("count");
                config.AddCommand<DeleteFunctionCommand>("delete");
                config.AddCommand<WriteFunctionCommand>("write");
            });

            app.Run(args);

        }
    }
}
