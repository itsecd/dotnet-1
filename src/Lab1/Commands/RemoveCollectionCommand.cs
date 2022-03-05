using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;
using Lab1.Model;

namespace Lab1.Commands
{
    public class RemoveCollectionCommand : Command<RemoveCollectionCommand.RemoveCollectionSettings>
    {

        public class RemoveCollectionSettings : CommandSettings
        {
        }

        private readonly IOperationsRepository _operationsRepository;

        public RemoveCollectionCommand(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveCollectionSettings settings)
        {
            _operationsRepository.RemoveCollection();
            return 0;
        }

    }
}