using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;



namespace PromProgLab1.Commands
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
            var removePrompt = new TextPrompt<int>("[blue]Введите индекс операции, которую хотите удалить: [/]");
            int removeIndex = AnsiConsole.Prompt(removePrompt);
            _operationsRepository.RemoveAt(removeIndex);
            return 0;
        }
    }
}