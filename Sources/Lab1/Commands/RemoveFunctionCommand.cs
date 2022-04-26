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
            if (_functionsRepository == null)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }

            var index = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс функции в коллекции для вычисления значения функции >=0: [/]")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]Индекс должен быть больше или равен нулю[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            _functionsRepository.RemoveFunction(index);
            return 0;
        }
    }
}
