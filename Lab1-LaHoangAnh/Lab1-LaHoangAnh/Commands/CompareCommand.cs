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

        public CompareCommand(IFigureRepository fi)
        {
            _figuresRepository = fi;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareSettings settings)
        {
            int id1 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс первой фигуры :[/]"));
            int id2 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс второй фигуры (отличный от {id1}):[/]"));
            var List = _figuresRepository.GetList();
            AnsiConsole.WriteLine($"Результат сравнения: {List[id1].Equals(List[id2])}");
            return 0;
        }
    }
}
