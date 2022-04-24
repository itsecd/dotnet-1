using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _functionsRepository.RemoveFunction(
                AnsiConsole.Prompt(new TextPrompt<int>("[blue]Индекс функции в коллекции для удаления: [/]")));
            return 0;
        }



    }
}
