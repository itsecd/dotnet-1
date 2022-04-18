using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareFunctionCommand : Command<CompareFunctionCommand.CompareFunctionSettings>
    {
        public class CompareFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public CompareFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFunctionSettings settings)
        {
            int inputIndex1 = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input index of the first function you want to compare: [/]"));
            int inputIndex2 = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input index of the second function you want to compare: [/]"));

            if (inputIndex1 < 0 || inputIndex2 < 0)
            {
                AnsiConsole.MarkupLine("[red]Index is out of range[/]");
                return -1;
            }

            var a = _functionsRepository.CompareFunction(inputIndex1, inputIndex2) ? "[green1]The functions are equal[/]" : "[red]The functions arn't equal[/]";
            AnsiConsole.MarkupLine($"{a}");
            AnsiConsole.MarkupLine("[green1]Done![/]");
            return 0;
        }
    }
}
