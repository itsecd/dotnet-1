using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Repository;
using Lab1.Infrastructure;
using Lab1.Commands;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMatrixRepository, MatrixStorage>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddMatrixCommand>("add");
                config.AddCommand<DeleteMatrixCommand>("delete");
                config.AddCommand<ClearRepositoryCommand>("clear");
                config.AddCommand<PrintRepositoryCommand>("print");
                config.AddCommand<CompareMatrixCommand>("compare");
                config.AddCommand<MinNormCommand>("min-norm");
                config.AddCommand<ModifyMatrixCommand>("modify");
            });
            app.Run(args);
        }
    }
}
