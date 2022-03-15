using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class CountFunctionCommand : Command<CountFunctionCommand.CountFunctionSettings>
    {
        public class CountFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public CountFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CountFunctionSettings settings)
        {
            //Menu.Menu.CountMenu(ref functionRepository);
            Menu.Menu.CountMenu(ref functionRepository);

            return 0;
        }

    }
}
