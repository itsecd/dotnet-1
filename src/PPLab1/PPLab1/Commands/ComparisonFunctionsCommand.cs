using PPLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PPLab1.Commands
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
            int inputIndex1 = AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input index of the first function you want to compare: [/]"));
            int inputIndex2 = AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input index of the second function you want to compare: [/]"));

            if(inputIndex1 < 0 || inputIndex2 < 0)
            {
                AnsiConsole.MarkupLine($"[red]Index is out of range[/]");
                return -1;
            }
            if(_functionsRepository.ComparisonFunctions(inputIndex1, inputIndex2) == true)
            {
                AnsiConsole.MarkupLine($"[seagreen1]The functions are equal[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]The functions arn't equal[/]");
            }
            AnsiConsole.MarkupLine($"[skyblue1]Done![/]");
            return 0;
        }
    }
}
