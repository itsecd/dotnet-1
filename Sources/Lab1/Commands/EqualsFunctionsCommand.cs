using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

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
            var index1 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс 1 функции в коллекции для сравнения: [/]"));

            var index2 = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Индекс 2 функции в коллекции для сравнения: [/]"));

            AnsiConsole.WriteLine(_functionsRepository
                .GetFunctions()[index1]
                .Equals(_functionsRepository
                    .GetFunctions()[index2]));
            return 0;
        }
    }
}
