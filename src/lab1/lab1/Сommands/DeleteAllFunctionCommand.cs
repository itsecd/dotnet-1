using lab1.services.interfaces;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1.Commands
{
    public class DeleteAllFunctionCommand : Command<DeleteAllFunctionCommand.DeleteAllFunctionSettings>
    {
        public class DeleteAllFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public DeleteAllFunctionCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllFunctionSettings settings)
        {
            _functionsRepository.Clear();
            AnsiConsole.MarkupLine("[green1]Done!");
            return 0;
        }


    }
}
