using System;
using Laba1.Model;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using Laba1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Laba1.Commands;

namespace Laba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigures3DRepository, XmlFigures3DRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigure3DCommand>("Add");
                config.AddCommand<PrintAllFigure3DCommand>("Print");
                config.AddCommand<RemoveFigure3DCommand>("Remove");
                config.AddCommand<RemoveAllFigure3DCommand>("RemoveAll");
                config.AddCommand<CompareFigures3DCommand>("Compare");
                config.AddCommand<GetMinParallelepipedCommand>("MinFrame");
            });
            app.Run(args);
        }
    }
}
