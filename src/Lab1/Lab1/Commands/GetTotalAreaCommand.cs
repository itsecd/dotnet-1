using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetTotalAreaCommand : Command<GetTotalAreaCommand.GetTotalAreaSettings>
    {
        public class GetTotalAreaSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public GetTotalAreaCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetTotalAreaSettings settings)
        {
            var userChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Каким способом посчитать суммарную площадь?")
                .AddChoices("С помощью Linq", "С помощью функции, реализованной вручную"));

            if (userChoice == "С помощью Linq")
            {
                AnsiConsole.Write($"Суммарная площадь всех фигур = {_figuresRepository.GetTotalAreaLinq()}");
            }
            else
            {
                AnsiConsole.Write($"Суммарная площадь всех фигур = {_figuresRepository.GetTotalAreaManually()}");
            }
            return 0;
        }
    }
}
