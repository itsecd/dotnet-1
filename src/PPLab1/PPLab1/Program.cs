using System;
using System.Collections.Generic;
using PPLab1.Model;
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
            Function f1 = new LogFunct()
            {
                Elems = new Data(10, 5)
            };
            Function f2 = new Const()
            {
                Elems = new Data(8, 3)
            };
            Function f3 = new PowerFunct()
            {
                Elems = new Data(2, 7)
            };
            Function f4 = new PowerFunct()
            {
                Elems = new Data(2, 7)
            };

            List<Function> functions = new() { f1, f2, f3, f4 };

            foreach (Function ff in functions)
            {
                AnsiConsole.WriteLine(ff.ToString());
            }


            //var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
            //   .Title("Select function type: ")
            //   .AddChoices("Constant", "Power function", "Exponential function", "Logarithm"));


            //int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[green]Input insertion index: [/]"));


            //Function newFunction = functionType switch
            //{
            //    "Constant" => new Const(
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
            //        ),
            //    "Power function" => new PowerFunct(
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input power: [/]")),
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
            //        ),
            //    "Exponential function" => new ExpFunct(
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input exponent: [/]")),
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
            //        ),
            //    "Logarithm" => new LogFunct(
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input base: [/]")),
            //        AnsiConsole.Prompt(new TextPrompt<int>("[green]Input coefficient: [/]"))
            //        ),
            //    _ => null
            //}; 

            //if (newFunction == null)
            //{
            //    AnsiConsole.MarkupLine($"[red]Unknowen function: {functionType}[/]");
            //}

            //functions.Add(newFunction);





            var value = 8;

            var max_result2 = functions.Max(f => (double)f.calc_funct(value));

            var res = (from func in functions
                       where func.calc_funct(value) == max_result2
                       select func).FirstOrDefault();

            AnsiConsole.WriteLine(res.ToString()); ;











        }
    }
}
