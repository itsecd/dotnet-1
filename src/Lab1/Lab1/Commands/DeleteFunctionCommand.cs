using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteFunctionCommand : Command<DeleteFunctionCommand.DeleteFunctionSettings>
    {
        public class DeleteFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public DeleteFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFunctionSettings settings)
        {
            int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input the remove index: [/]"));

            _functionsRepository.DeleteFunction(inputIndex);
            AnsiConsole.MarkupLine("[green1]Done![/]");

            return 0;
        }
    }
}
