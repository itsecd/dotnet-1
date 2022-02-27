using PPLab1.Model;
using PPLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PPLab1.Commands
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

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFunctionSettings settings)
        {
            int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input the remove index: [/]"));

            _functionsRepository.RemoveFunction(inputIndex);
            AnsiConsole.MarkupLine($"[skyblue1]Done![/]");

            return 0;
        }

        
    }
}
