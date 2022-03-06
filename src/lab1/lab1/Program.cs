using Spectre.Console;
using System;
using System.Collections.Generic;
using lab1.Functions;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string textMenu;
            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Variables");
            table.AddColumn("Сalculated value");
            table.AddColumn("Derivative ");
            List<Function> functionList = new List<Function>();
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose your next action:")
            .PageSize(10)
            .AddChoices("Function selection"));
            switch (menu)
            {
                case "Function selection":
                    textMenu = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("Choose a function type")
                        .PageSize(10)
                        .AddChoices("Constant", "Power Function",
                        "Exponential Function", "LogarithmicFunction"));
                    Function function = textMenu switch
                    {
                        "Constant" => new Constant(new Data(1,
                          AnsiConsole.Ask<int>("Enter a number"))),

                        "Power Function" => new PowerFunction(new Data(
                          AnsiConsole.Ask<int>("Enter a variable"),
                          AnsiConsole.Ask<int>("Enter a coefficient"),
                          AnsiConsole.Ask<int>("Enter a degree"))),

                        "Exponential Function" => new ExponentialFunction(new Data(
                          AnsiConsole.Ask<int>("Enter a variable"),
                          AnsiConsole.Ask<int>("Enter a coefficient"),
                          AnsiConsole.Ask<int>("Enter a function base"))),

                        "Logarithmic Function" => new LogarithmicFunction(new Data(
                          AnsiConsole.Ask<int>("Enter a variable"),
                          AnsiConsole.Ask<int>("Enter a coefficient"),
                          AnsiConsole.Ask<int>("Enter a base of the logarithm"))),

                        _ => throw new NotImplementedException()
                    };
                    AnsiConsole.Clear();
                    functionList.Add(function);
                    foreach (var function1 in functionList)
                    {
                        table.AddRow(function1.GetType().Name, function1.ToString(),
                            function1.Calculation().ToString(), function1.Derivative().ToString());
                    }
                    AnsiConsole.Write(table);
                    break;
            }
        }
    }
}
