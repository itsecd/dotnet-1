using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteAllFunctionCommand : Command<DeleteAllFunctionCommand.DeleteAllFunctionSettings>
    {
        public class DeleteAllFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public DeleteAllFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllFunctionSettings settings)
        {
            _functionsRepository.DeleteAllFunction();
            AnsiConsole.MarkupLine($"[green1]Done![/]");
            return 0;
        }


    }
}
