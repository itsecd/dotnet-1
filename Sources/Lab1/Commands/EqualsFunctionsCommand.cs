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
    public class EqualsFunctionsCommand : Command<EqualsFunctionsCommand.EqualsFunctionsSettings>
    {
        public class EqualsFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public EqualsFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] EqualsFunctionsSettings settings)
        {
            if (_functionsRepository == null)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }


            var index1 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс 1 функции в коллекции для сравнения: [/]")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]Индекс должен быть больше или равен нулю[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));


            var index2 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс 2 функции в коллекции для сравнения: [/]")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]Индекс должен быть больше или равен нулю[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));

            AnsiConsole.WriteLine(_functionsRepository
                .GetFunction(index1)!
                    .Equals(_functionsRepository
                    .GetFunction(index2)));
            return 0;
        }
    }
}
