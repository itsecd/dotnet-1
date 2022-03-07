using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ComparisonFunctionsCommand : Command<ComparisonFunctionsCommand.ComparisonFunctionsSettings>
    {
        public class ComparisonFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public ComparisonFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComparisonFunctionsSettings settings)
        {
            int index1 = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter the index of the first function:[/]"));
            int index2 = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter the index of the second function:[/]"));

            try
            {
                if (_functionsRepository.ComparisonFunctions(index1, index2))
                {
                    AnsiConsole.MarkupLine("[blue]Functions are equal.[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Functions are not equal.[/]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
}
