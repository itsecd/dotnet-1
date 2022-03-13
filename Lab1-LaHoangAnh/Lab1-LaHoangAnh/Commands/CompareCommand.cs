using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareCommand : Command<CompareCommand.CompareSettings>
    {
        public class CompareSettings : CommandSettings { }

        private readonly IFigureRepository _figuresRepository;

        public CompareCommand(IFigureRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareSettings settings)
        {
            int Index1 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс первого фигура :[/]"));
            int Index2 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс второго фигура (различен от {Index1}):[/]"));
            var figures = _figuresRepository.GetList();
            AnsiConsole.WriteLine($"Результат сравнения: {figures[Index1].Equals(figures[Index2])}");
            return 0;
        }
    }
}
