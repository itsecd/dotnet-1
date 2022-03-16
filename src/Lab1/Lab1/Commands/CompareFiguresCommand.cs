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
        private readonly IFiguresRepository _figureRepository;
        public CompareFiguresCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFiguresSettings settings)
        {

            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>("[green]Enter the index of the first figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var firstFigure = _figureRepository.GetFigure(firstIndex);
            var firstTable = new Table();
            firstTable.AddColumn("Type");
            firstTable.AddColumn("Info");
            firstTable.AddColumn("Perimeter");
            firstTable.AddColumn("Area");
            firstTable.AddRow(firstFigure.GetType().Name, firstFigure.ToString(),
                              firstFigure.GetPerimeter().ToString(), firstFigure.GetArea().ToString());
            AnsiConsole.Write(firstTable);
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>("[green]\nEnter the index of the second figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var secondFigure = _figureRepository.GetFigure(secondIndex);
            var secondTable = new Table();
            secondTable.AddColumn("Type");
            secondTable.AddColumn("Info");
            secondTable.AddColumn("Perimeter");
            secondTable.AddColumn("Area");
            secondTable.AddRow(secondFigure.GetType().Name, secondFigure.ToString(),
                              secondFigure.GetPerimeter().ToString(), secondFigure.GetArea().ToString());
            AnsiConsole.Write(secondTable);
            bool isEqual = _figureRepository.CompareFigures(firstIndex, secondIndex);
            AnsiConsole.WriteLine($"\nFigures with indexes {firstIndex} and {secondIndex} {(isEqual ? "are" : "are not")} equal!\n");
            return 0;
        }
    }
}
