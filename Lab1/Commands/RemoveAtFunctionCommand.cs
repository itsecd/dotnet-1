using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1.Commands
{
    class RemoveAtFunctionCommand : Command<RemoveAtFunctionCommand.RemoveAtFunctionSettings>
    {
        public class RemoveAtFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public RemoveAtFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAtFunctionSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Enter the index of the function to be removed :[/]"));
            _functionsRepository.RemoveAt(index);
            return 0;
        }
    }
}
