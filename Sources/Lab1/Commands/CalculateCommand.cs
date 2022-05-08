using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CalculateCommand : Command<CalculateCommand.CalculateSettings>
    {
        public class CalculateSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public CalculateCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] CalculateSettings settings)
        {
            var index = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Enter function index to calculate function value: [/]"));

            var functions = _functionsRepository.GetFunctions();
            var f = functions[index];

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]Name of function[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));
            table.AddColumn(new TableColumn("[white]Antiderivative[/]"));
            table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]", $"[yellow]{f.GetDerivative()}[/]", $"[yellow]{f.GetAntiderivative()} + C[/]");

            AnsiConsole.Write(table);
            AnsiConsole.WriteLine(Math.Round(f.Calculate(
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter the x value to calculate the value of the function: [/]"))), 3).ToString());
            return 0;
        }
    }
}
