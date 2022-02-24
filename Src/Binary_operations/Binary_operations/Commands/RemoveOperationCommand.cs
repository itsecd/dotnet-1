using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Binary_operations.Commands
{
    public class RemoveOperationCommand : Command<RemoveOperationCommand.RemoveOperationSettings>
    {
        public class RemoveOperationSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public RemoveOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveOperationSettings settings)
        {
            var textDelete = new TextPrompt<int>("[blue]Введите индекс операции, которую хотите удалить: [/]");
            int indexDelete = AnsiConsole.Prompt(textDelete);
            _operationsRepository.RemoveOperation(indexDelete);
            return 0;
        }


    }
}

