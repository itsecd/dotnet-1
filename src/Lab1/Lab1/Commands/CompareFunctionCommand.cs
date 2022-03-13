using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class CompareFunctionCommand : Command<CompareFunctionCommand.CompareFunctionSettings>
    {
        public class CompareFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public CompareFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFunctionSettings settings)
        {
            Menu.Menu.CompareMenu(ref functionRepository);

            return 0;
        }

    }
}
