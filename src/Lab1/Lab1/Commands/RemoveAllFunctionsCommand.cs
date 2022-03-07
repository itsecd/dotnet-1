using Lab1.Repositories;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveAllFunctionsCommand : Command<RemoveAllFunctionsCommand.RemoveAllFunctionsSettings>
    {
        public class RemoveAllFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public RemoveAllFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllFunctionsSettings settings)
        {
            _functionsRepository.RemoveAllFunctions();
            return 0;
        }
    }
}
