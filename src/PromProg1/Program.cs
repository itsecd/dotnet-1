using Spectre.Console;
using System;
using PromProg1.Models;
using PromProg1.Repository;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PromProg1.Infrastructure;
using Spectre.Console.Cli;
using PromProg1.Commands;

namespace PromProg1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IOperationRepository, XMLOperationRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<InsertOperationCommand>("insert");
                config.AddCommand<RemoveOperationCommand>("remove");
                //config.AddCommand<GetAllFeaturesCommand>("print");
            });

            app.Run(args);
        }
    }
}
