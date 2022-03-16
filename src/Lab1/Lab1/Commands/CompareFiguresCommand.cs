using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareFiguresCommand : Command<CompareFiguresCommand.CompareFiguresSettings>
    {
        public class CompareFiguresSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public CompareFiguresCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFiguresSettings settings)
        {
            var leftIndex = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой фигуры для сравнения: "));
            var rightIndex = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй фигуры для сравнения: "));
            var firstFigure = _figuresRepository.GetFigures()[leftIndex];
            var secondFigure = _figuresRepository.GetFigures()[rightIndex];
            var table = new Table();

            table.AddColumn("Первая фигура");
            table.AddColumn("Вторая фигура");

            table.AddRow(firstFigure.GetType().Name, secondFigure.GetType().Name);
            table.AddRow(firstFigure.ToString(), secondFigure.ToString());

            table.Centered();
            AnsiConsole.Write(table);

            if (firstFigure.GetArea() > secondFigure.GetArea())
            {
                AnsiConsole.Write("Первая фигура больше второй");
            }
            else if (firstFigure.GetArea() < secondFigure.GetArea())
            {
                AnsiConsole.Write("Вторая фигура больше первой");
            }
            else
            {
                AnsiConsole.Write("Первая и вторая фигуры имеют одинаковый размер");
            }
            return 0;
        }
    }
}
