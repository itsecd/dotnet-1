using PPLab1.Model;
using PPLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using PPLab1.Infrastructure;
using Spectre.Console.Cli;
using PPLab1.Commands;

namespace PPLab1
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
                config.AddCommand<PrintFunctionsCommand>("print");
            });

            app.Run(args);
            

           
           
            ////int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[green]Input insertion index: [/]"));



            //var value = 8;

            //var max_result2 = functions.Max(f => (double)f.calc_funct(value));

            //var res = (from func in functions
            //           where func.calc_funct(value) == max_result2
            //           select func).FirstOrDefault();

            //AnsiConsole.WriteLine(res.ToString()); ;




        }
    }
}
