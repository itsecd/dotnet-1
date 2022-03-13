using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class DeleteFunctionCommand : Command<DeleteFunctionCommand.DeleteFunctionSettings>
    {
        public class DeleteFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public DeleteFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFunctionSettings settings)
        {
            Menu.Menu.DeleteMenu(ref functionRepository);

            return 0;
        }

    }
}
