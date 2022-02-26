using PPLab1.Model;
using PPLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using System.Xml.Serialization;
using System.IO;


namespace PPLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var functRepository = new FunctionsRepository();
           
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Select function type: ")
               .AddChoices("Constant", "Power function", "Exponential function", "Logarithm"));


            //int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[green]Input insertion index: [/]"));


            Function newFunction = functionType switch
            {
                "Constant" => new Const(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
                    ),
                "Power function" => new PowerFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input power: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
                    ),
                "Exponential function" => new ExpFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input exponent: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
                    ),
                "Logarithm" => new LogFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input base: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
                    ),
                _ => null
            };

            if (newFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknowen function: {functionType}[/]");
            }

            //functRepository.AddFunction(newFunction);

            functRepository.PrintFunctions();

            functRepository.RemoveAllFunctions();

            functRepository.PrintFunctions();

            //functRepository.RemoveFunction(1);

            //functRepository.PrintFunctions();



            //var value = 8;

            //var max_result2 = functions.Max(f => (double)f.calc_funct(value));

            //var res = (from func in functions
            //           where func.calc_funct(value) == max_result2
            //           select func).FirstOrDefault();

            //AnsiConsole.WriteLine(res.ToString()); ;











        }
    }
}
