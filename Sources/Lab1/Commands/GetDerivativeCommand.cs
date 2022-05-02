using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    internal class GetDerivativeCommand : Command<GetDerivativeCommand.GetDerivativeSettings>
    {
        public class GetDerivativeSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetDerivativeCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] GetDerivativeSettings settings)
        {
            var index = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс функции в коллекции для вычисления производной: [/]")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]Индекс должен быть больше или равен нулю[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));

            AnsiConsole.WriteLine(_functionsRepository.GetFunctions()[index]
                        .GetDerivative().ToString());
            return 0;
        }
    }
}
