using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using Lab1.Commands;
using Lab1.Infrastructure;
using Lab1.Model;
using Lab1.Repositories;
using Lab1.Shapes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1
{
    public class main
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFiguresRepository, XmlFiguresRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
            });
            
            app.Run(args);
        }
    }
}
