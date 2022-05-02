using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CalculateCommand : Command<CalculateCommand.CalculateSettings>
    {
        public class CalculateSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public CalculateCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] CalculateSettings settings)
        {
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

            AnsiConsole.WriteLine(_functionsRepository
                .GetFunctions()[index]
                    .Calculate(
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Введите значение х для вычисления значения функции: [/]"))).ToString());
            return 0;
        }
    }
}
