using Binary_operations.Repositories;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Binary_operations.Commands
{
    public class MinOperation : Command<MinOperation.MinOperationSettings>
    {
        public class MinOperationSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public MinOperation(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinOperationSettings settings)
        {
            _operationsRepository.MinElement();
            return 0;
        }
    }
}

