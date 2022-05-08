using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class EqualsFunctionsCommand : Command<EqualsFunctionsCommand.EqualsFunctionsSettings>
    {
        public class EqualsFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public EqualsFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] EqualsFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetFunctions();
            var index1 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Enter the index of the first function in the collection to compare: [/]"));

            var index2 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Enter the index of the second function in the collection to compare: [/]"));

            var first = functions[index1];
            var second = functions[index1];

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]Name of function[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));
            table.AddColumn(new TableColumn("[white]Antiderivative[/]"));
            table.AddRow($"[yellow]{first.GetType().Name}[/]", $"[yellow]{first.ToString()}[/]", $"[yellow]{first.GetDerivative()}[/]", $"[yellow]{first.GetAntiderivative()} + C[/]");
            table.AddRow($"[yellow]{second.GetType().Name}[/]", $"[yellow]{second.ToString()}[/]", $"[yellow]{second.GetDerivative()}[/]", $"[yellow]{second.GetAntiderivative()} + C[/]");

            AnsiConsole.Write(table);
            AnsiConsole.WriteLine(first.Equals(second));
            return 0;
        }
    }
}
