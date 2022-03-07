using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFunctionCommand : Command<RemoveFunctionCommand.RemoveFunctionSettings>
    {
        public class RemoveFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public RemoveFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFunctionSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter index to remove from collection:[/]"));
            try
            {
                _functionsRepository.RemoveFunction(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
}
