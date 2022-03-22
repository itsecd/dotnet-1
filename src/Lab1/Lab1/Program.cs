using System;
using System.Linq;
using Lab1.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Lab1.Repository;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Lab1.Commands;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMatricesRepository, XmlMatricesRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddMatrixCommand>("add");
                config.AddCommand<GetAllMatricesCommand>("print");
                config.AddCommand<RemoveMatrixCommand>("remove");
                config.AddCommand<ClearRepositoryCommand>("clear");
                config.AddCommand<CompareMatricesCommand>("compare");
            });

            app.Run(args);
        }
    }


}
