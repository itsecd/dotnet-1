using Binary_operations.Repositories;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

