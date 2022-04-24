using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Models;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Xml;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XmlFunctionsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<GetAllFunctionsCommand>("print");
            });
            
            app.Run(args);
        }
    }
}

