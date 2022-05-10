using prProgLab1.Model;
using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace prProgLab1.Commands
{
    public class MinDerivativeCommand : Command<MinDerivativeCommand.MinDerivativeSettings>
    {
        public class MinDerivativeSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public MinDerivativeCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinDerivativeSettings settings)
        {
            int x = AnsiConsole.Prompt(new TextPrompt<int>("[red]Введите 'x' :[/]"));

            AnsiConsole.MarkupLine($"Минимальный из минимумов функций (с ручными вычислениями): {_functionsRepository.MinFunc(x)}");
            AnsiConsole.MarkupLine($"Минимальный из минимумов функций (с методом из Linq): {_functionsRepository.MinFuncLINQ(x)}");

            return 0;
        }
    }
}