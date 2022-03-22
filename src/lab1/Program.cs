using lab1.Repositories;
using Lab1.Commands;
using Lab1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMatrixRepository, XmlMatrixRepository>();

            var registrar = new TypeRegistrar(serviceCollection);

            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<InsertCommand>("insert")
                .WithDescription("Insert new matrix by index");
                config.AddCommand<PrintAllCommand>("print_all")
                .WithDescription("Print all matrices (if the count of matrices is greater than 10, then it print only the first 10)");
                config.AddCommand<PrintMatrixCommand>("print_matrix")
                .WithDescription("Print matrix by index");
                config.AddCommand<CompareCommand>("compare")
                .WithDescription("Compares 2 matrices");
                config.AddCommand<RemoveAtCommand>("remove")
                .WithDescription("Remove matrix by index");
                config.AddCommand<ClearCommand>("clear")
                .WithDescription("Delete all matrices");
                config.AddCommand<GetAbsMaxCommand>("abs_max")
                .WithDescription("Finds the matrix with the smallest norm of maximum modulus");
                config.AddCommand<GetAbsMaxLinqCommand>("abs_max_linq")
                .WithDescription("Finds the matrix with the smallest norm of maximum modulus (use linq)");
                config.AddCommand<SetValueCommand>("set")
                .WithDescription("Set value in the matrix by index");
            });

            app.Run(args);
        }
    }
}
