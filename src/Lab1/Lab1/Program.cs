using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Function function1 = new LogarithmFunction(2);
            Function function2 = new LogarithmFunction(4);
            Function function3 = new ExponentialFunction(5);
            Function function4 = new PowerFunction(2, 4);

            List<Function> functions = new() { function1, function2, function3, function4 };

            double value = 20;
            Function maxFunction = function1;
            var maxResult = maxFunction.Calculate(value);

            foreach (var function in functions)
            {
                var result = function.Calculate(value);

                if (maxResult < result)
                {
                    maxResult = result;
                    maxFunction = function;
                }
            }

            Console.WriteLine(maxFunction);
            Console.WriteLine(functions.Max(function => function.Calculate(value)));




            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Select a function type:")
               .AddChoices("Constant function", "Power function", "Exponential function", "Logarithm function"));

            Function selectedFunction = functionType switch
            {
                "Constant function" => new ConstantFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a coefficient:[/]"))
                    ),
                "Power function" => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a coefficient:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter degree:[/]"))
                    ),
                "Exponential function" => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a base:[/]"))
                    ),
                "Logarithm function" => new LogarithmFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a base:[/]"))
                    ),
                _ => null
            };


            if (selectedFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown function: {functionType}[/]");
            }

            functions.Add(selectedFunction);



            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Function");
            table.AddColumn("Derivative");
            int counter = 0;

            foreach(Function function in functions)
            {
                if (counter < 10)
                {
                    table.AddRow(function.GetType().Name, function.ToString(), function.Derivative().ToString());
                    ++counter;
                    continue;
                }
                table.AddRow("...", "...", "...");
                break;
            }

            AnsiConsole.Write(table);    

        }
    }
}
