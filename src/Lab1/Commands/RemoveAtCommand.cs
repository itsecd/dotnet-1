using Lab1.Repository;
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

        private readonly IOperationRepository _operationsRepository;

        public RemoveAtCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAtSettings settings)
        {
            var strIndex = new TextPrompt<int>("[orange]Введите индекс операции, которую хотите удалить: [/]");
            int index = AnsiConsole.Prompt(strIndex);
            _operationsRepository.RemoveAt(index);

            return 0;
        }

    }
}