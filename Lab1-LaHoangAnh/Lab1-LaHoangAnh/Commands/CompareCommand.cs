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
            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс первого фигура :[/]"));
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс второго фигура (различен от {firstIndex}):[/]"));
            var figures = _figuresRepository.GetList();
            AnsiConsole.WriteLine($"Результат сравнения: {figures[firstIndex].Equals(figures[secondIndex])}");
            return 0;
        }
    }
}
