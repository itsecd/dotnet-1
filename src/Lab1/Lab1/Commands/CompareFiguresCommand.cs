using Lab1.Repositories;
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
            var leftIndex = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой фигуры для сравнения:"));
            var rightIndex = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй фигуры для сравнения:"));
            var firstFigure = _figuresRepository.GetFigures()[leftIndex];
            var secondFigure = _figuresRepository.GetFigures()[rightIndex];
            var table = new Table();

            table.AddColumn("First figure");
            table.AddColumn("Seconds figure");

            table.AddRow(firstFigure.GetType().Name, secondFigure.GetType().Name);
            table.AddRow(firstFigure.ToString(), secondFigure.ToString());

            table.Centered();
            AnsiConsole.Write(table);

            if (firstFigure.GetArea() > secondFigure.GetArea())
            {
                AnsiConsole.Write("First figure is bigger than second");
            }
            else if (firstFigure.GetArea() < secondFigure.GetArea())
            {
                AnsiConsole.Write("Second figure is bigger than first");
            }
            else
            {
                AnsiConsole.Write("First and second figures are the same size");
            }
            return 0;
        }
    }
}
