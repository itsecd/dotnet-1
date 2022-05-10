using System;
using System.Collections.Generic;
using prProgLab1.Model;
using prProgLab1.Repository;
using prProgLab1.Infrastructure;
using prProgLab1.Commands;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace prProgLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XmlStorageRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<InsertFunctionCommand>("insert");
                config.AddCommand<PrintFunctionsCommand>("print");
                config.AddCommand<RemoveFunctionCommand>("remove");
                config.AddCommand<ClearFunctionsCommand>("clear");
                config.AddCommand<ComputeFunctionCommand>("compute");
                config.AddCommand<MinDerivativeCommand>("min");
                config.AddCommand<CompareFunctionsCommand>("compare");
            });

            app.Run(args);
        }
    }
}
