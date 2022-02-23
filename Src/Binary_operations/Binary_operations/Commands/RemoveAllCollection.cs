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
    internal class RemoveAllCollection : Command<RemoveAllCollection.RemoveAllCollectionSettings>
    {
        public class RemoveAllCollectionSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public RemoveAllCollection(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllCollectionSettings settings)
        {
            _operationsRepository.RemoveCollection();
            return 0;
        }
    }
}

