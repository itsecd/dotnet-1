using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class RemoveOperationCommand : Command<RemoveOperationCommand.RemoveOperationSettings>
    {
        public class RemoveOperationSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public RemoveOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveOperationSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс"));
            _operationsRepository.RemoveOperation(index);
            return 0;
        }
    }
}
