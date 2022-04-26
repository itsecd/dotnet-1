using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class PrintAllFunctionsCommand : Command<PrintAllFunctionsCommand.PrintAllFunctionsSettings>
    {
        public class PrintAllFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public PrintAllFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] PrintAllFunctionsSettings settings)
        {

            var functions = _functionsRepository.GetFunctions();

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]NameOfFunction[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));

            int count = 0;
            int maxCount = 10;
            foreach (Function f in functions)
            {
                switch (f.GetType().Name)
                {
                    case "ConstantFunction":
                        table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]", $"[yellow]{f.GetDerivative()}[/]");
                        break;
                    case "LinearFunction":
                        table.AddRow($"[green]{f.GetType().Name}[/]", $"[green]{f.ToString()}[/]", $"[green]{f.GetDerivative()}[/]");
                        break;
                    case "QuadraticFunction":
                        table.AddRow($"[magenta]{f.GetType().Name}[/]", $"[magenta]{f.ToString()}[/]", $"[magenta]{f.GetDerivative()}[/]");
                        break;
                    case "SinusFunction":
                        table.AddRow($"[cyan]{f.GetType().Name}[/]", $"[cyan]{f.ToString()}[/]", $"[cyan]{f.GetDerivative()}[/]");
                        break;
                    case "CosinusFunction":
                        table.AddRow($"[blue]{f.GetType().Name}[/]", $"[blue]{f.ToString()}[/]", $"[blue]{f.GetDerivative()}[/]");
                        break;
                }
                count += 1;
                if (count >= maxCount && functions.Count > maxCount)
                {
                    table.AddRow("[white]...[/]", "[white]...[/]", "[white]...[/]");
                    break;
                }
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
