using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFunctionCommand : Command<RemoveFunctionCommand.RemoveFunctionSettings>
    {
        public class RemoveFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public RemoveFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public void Print(List<Function> functions)
        {
            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]Name of function[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));
            table.AddColumn(new TableColumn("[white]Antiderivative[/]"));

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
                    case "SineFunction":
                        table.AddRow($"[cyan]{f.GetType().Name}[/]", $"[cyan]{f.ToString()}[/]", $"[cyan]{f.GetDerivative()}[/]", $"[cyan]{f.GetAntiderivative()} + C[/]");
                        break;
                    case "CosineFunction":
                        table.AddRow($"[blue]{f.GetType().Name}[/]", $"[blue]{f.ToString()}[/]", $"[blue]{f.GetDerivative()}[/]", $"[blue]{f.GetAntiderivative()} + C[/]");
                        break;
                }
            }
            AnsiConsole.Write(table);
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFunctionSettings settings)
        {
            var functions = _functionsRepository.GetFunctions();
            Print(functions);

            var index = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Enter the index of the function to remove: [/]"));

            _functionsRepository.RemoveFunction(index);
            AnsiConsole.Clear();
            AnsiConsole.WriteLine("\t\tItem removed");
            functions = _functionsRepository.GetFunctions();
            Print(functions);
            return 0;
        }
    }
}
