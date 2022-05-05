using lab1.Commands;
using lab1.Infrastructure;
using lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionRepository, XmlFunctionRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunction>("add");
                config.AddCommand<DeleteFunction>("delete");
                config.AddCommand<GetFunction>("get");
                config.AddCommand<CompareFunction>("compare");
                config.AddCommand<CalcFunction>("calculate");
                config.AddCommand<DerivativeFunction>("derivative");
                config.AddCommand<MaxFunction>("max");
            });

            app.Run(args);
        }
    }
}
