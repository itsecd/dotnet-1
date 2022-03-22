using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveAtCommand : Command<RemoveAtCommand.RemoveAtSettings>
    {

        public class RemoveAtSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public RemoveAtCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAtSettings settings)
        {
            AnsiConsole.MarkupLine($"[blue]Count matrix in collection: {_matricesRepository.GetAll().Count} [/]");
            var index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter index to remove matrix: [/]"));

            _matricesRepository.RemoveAt(index);
            return 0;
        }

    }
}