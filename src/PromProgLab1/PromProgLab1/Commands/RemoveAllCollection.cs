using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
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
