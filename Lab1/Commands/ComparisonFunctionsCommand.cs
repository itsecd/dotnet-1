using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class ComparisonFunctionsCommand : Command<ComparisonFunctionsCommand.ComparisonFunctionsSettings>
    {
        public class ComparisonFunctionsSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public ComparisonFunctionsCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComparisonFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetAll();
            int indexFirst = AnsiConsole.Prompt(new TextPrompt<int>(
               "[green]Enter the index of the first function :[/]"));
            int indexSecond = AnsiConsole.Prompt(new TextPrompt<int>(
               "[green]Enter the index of the second function :[/]"));

            AnsiConsole.Write("Functions\n" + functions[indexFirst] + "\n" + functions[indexSecond]);

            if (functions[indexFirst].Equals(functions[indexSecond]))
                AnsiConsole.Write("\nAre equal");
            else
                AnsiConsole.Write("\nAre Not equal");
            return 0;
        }
    }
}
