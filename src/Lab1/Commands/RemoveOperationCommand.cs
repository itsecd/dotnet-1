using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;
using Lab1.Model;

namespace Lab1.Commands
{
    public class RemoveOperationCommand : Command<RemoveOperationCommand.RemoveOperationSettings>
    {

        public class RemoveOperationSettings : CommandSettings
        {
        }

        private readonly IOperationsRepository _operationsRepository;

        public RemoveOperationCommand(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveOperationSettings settings)
        {
            var strIndex = new TextPrompt<int>("[orange]Введите индекс операции, которую хотите удалить: [/]");
            int index = AnsiConsole.Prompt(strIndex);
            _operationsRepository.RemoveOperation(index);

            return 0;
        }

    }
}