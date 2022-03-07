using Lab1.Repository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ClearCommand : Command<ClearCommand.ClearSettings>
    {

        public class ClearSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public ClearCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearSettings settings)
        {
            _operationsRepository.Clear();
            return 0;
        }

    }
}