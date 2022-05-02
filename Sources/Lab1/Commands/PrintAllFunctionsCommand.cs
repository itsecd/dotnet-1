using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

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
            if (_functionsRepository.GetFunctions().Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                AnsiConsole.WriteLine("Список пуст!");
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }

            var functions = _functionsRepository.GetFunctions();

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]NameOfFunction[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));
            table.AddColumn(new TableColumn("[white]Antiderivative[/]"));

            int count = 0;
            int maxCount = 10;
            foreach (Function f in functions)
            {
                switch (f.GetType().Name)
                {
                    case "ConstantFunction":
                        table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]", $"[yellow]{f.GetDerivative()}[/]", $"[yellow]{f.GetAntiderivative()} + C[/]");
                        break;
                    case "LinearFunction":
                        table.AddRow($"[green]{f.GetType().Name}[/]", $"[green]{f.ToString()}[/]", $"[green]{f.GetDerivative()}[/]", $"[green]{f.GetAntiderivative()} + C[/]");
                        break;
                    case "QuadraticFunction":
                        table.AddRow($"[magenta]{f.GetType().Name}[/]", $"[magenta]{f.ToString()}[/]", $"[magenta]{f.GetDerivative()}[/]", $"[magenta]{f.GetAntiderivative()} + C[/]");
                        break;
                    case "SinusFunction":
                        table.AddRow($"[cyan]{f.GetType().Name}[/]", $"[cyan]{f.ToString()}[/]", $"[cyan]{f.GetDerivative()}[/]", $"[cyan]{f.GetAntiderivative()} + C[/]");
                        break;
                    case "CosinusFunction":
                        table.AddRow($"[blue]{f.GetType().Name}[/]", $"[blue]{f.ToString()}[/]", $"[blue]{f.GetDerivative()}[/]", $"[blue]{f.GetAntiderivative()} + C[/]");
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
