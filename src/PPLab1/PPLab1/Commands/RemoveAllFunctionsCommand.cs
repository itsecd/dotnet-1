using PPLab1.Model;
using PPLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PPLab1.Commands
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
