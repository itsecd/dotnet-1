using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class WriteFunctionCommand : Command<WriteFunctionCommand.WriteFunctionSettings>
    {
        public class WriteFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public WriteFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] WriteFunctionSettings settings)
        {
            Menu.Menu.WriteMenu(ref functionRepository);

            return 0;
        }

    }
}
