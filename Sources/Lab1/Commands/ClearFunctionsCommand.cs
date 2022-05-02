using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ClearFunctionsCommand : Command<ClearFunctionsCommand.ClearFeaturesSettings>
    {
        public class ClearFeaturesSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public ClearFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] ClearFeaturesSettings settings)
        {
            _functionsRepository.Clear();
            AnsiConsole.WriteLine("Список функции очищен!");
            return 0;
        }
    }
}
