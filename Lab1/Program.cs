using Lab1.Model;
using System;
using System.Collections.Generic;
using Lab1.Services;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Lab1.Commands;

namespace Lab1
{

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XmlStorageRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<InsertFunctionCommand>("Insert");
                config.AddCommand<GetAllFunctionsCommand>("GetAllFunctions");
                config.AddCommand<RemoveAtFunctionCommand>("RemoveAt");
                config.AddCommand<ClearFunctionsCommand>("Clear");
                config.AddCommand<GetDerivativeFunctionCommand>("GetDerivative");
                config.AddCommand<ComputeFunctionCommand>("Compute");
            });

            app.Run(args);
            /*
            var repos = new XmlStorageRepository();
            //foreach (var function in repos.GetAll())
            //{
            //    Console.WriteLine(function);
            //}
            repos.Insert(0, new Constant(12));
            foreach (var function in repos.GetAll())
            {
                Console.WriteLine(function);
            }
            

            //var textPrompt = new TextPrompt<double>("[red]Enter a real number:[/]");
            //double val = AnsiConsole.Prompt(textPrompt);
            /*
            var table = new Table();
            table.AddColumns("Function", "Data", "Derivative");
            foreach (Function f in func)
            {
                table.AddRow(f.GetType().Name, f.ToString(), f.GetDerivative().ToString());
                //AnsiConsole.Write(new Markup($"[mediumorchid]Function ::: [/][lime]{f}[/]\n"));
            }
            AnsiConsole.Write(table);*/
            
            /*
            var minValue = func.Min(x => x.GetDerivative().GetValueFunc(2));
            var funcMinValue = func.First(x => x.GetDerivative().GetValueFunc(2) == minValue);
            Console.WriteLine(funcMinValue);
            Console.WriteLine(GetMinValueDerivative(func, 2));

            Function cs = new Cos();
            Console.WriteLine(cs.GetValueFunc(-10));

            Function sn = new Sin();
            Function sin = new Sin();
            Console.WriteLine(sn.GetValueFunc(10));

            Function test1 = new QuadraticFunction(1, 2, 3);

            Function test2 = new QuadraticFunction(1, 2, 3);
            Console.WriteLine(sn.Equals(sin));
            */
        }

        public static Function GetMinValueDerivative(List<Function> func, double arg)
        {
            if (func.Count == 0) throw new Exception("Your List is empty");
            double min = double.MaxValue;
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().Compute(arg) < min)
                    min = elem.GetDerivative().Compute(arg);
            }
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().Compute(arg) == min)
                    return elem;
            }
            throw new Exception("Unreal ERROR");
        }
    }
}
