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
                new TextPrompt<int>("[blue]Введите индекс функции для вычисления производной: [/]"));

            AnsiConsole.WriteLine(_functionsRepository.GetFunctions()[index]
                        .GetDerivative().ToString());
            return 0;
        }
    }
}
