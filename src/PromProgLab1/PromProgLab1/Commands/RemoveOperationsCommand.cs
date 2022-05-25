using PromProgLab1.Repositories;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
{
    internal class RemoveCollectionsCommand : Command<RemoveCollectionsCommand.RemoveCollectionsCommandSettings>
    {
        public class RemoveCollectionsCommandSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public RemoveCollectionsCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveCollectionsCommandSettings settings)
        {
            _operationsRepository.Clear();
            return 0;
        }
    }
}
