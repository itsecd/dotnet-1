using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using Lab1_3D.Repositories;

namespace Lab1_3D.Commands
{
    public class CompareFigures : Command<CompareFigures.CompareFiguresSettings>
    {
        public class CompareFiguresSettings : CommandSettings
        {
        }
        private readonly IFigures _figureRepository;
        public CompareFigures(IFigures figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFiguresSettings settings)
        {

            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>("[white]Enter the index of the first figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var firstFigure = _figureRepository.GetFigure(firstIndex);
            var firstTable = new Table();
            firstTable.AddColumn("Type");
            firstTable.AddColumn("Info");
            firstTable.AddColumn("SurfaceArea");
            firstTable.AddColumn("Volume");
            firstTable.AddRow(firstFigure.GetType().Name, firstFigure.ToString(),
                              firstFigure.GetSurfaceArea().ToString(), firstFigure.GetVolume().ToString());
            AnsiConsole.Write(firstTable);
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>("[white]\nEnter the index of the second figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var secondFigure = _figureRepository.GetFigure(secondIndex);
            var secondTable = new Table();
            secondTable.AddColumn("Type");
            secondTable.AddColumn("Info");
            secondTable.AddColumn("SurfaceArea");
            secondTable.AddColumn("Volume");
            secondTable.AddRow(secondFigure.GetType().Name, secondFigure.ToString(),
                              secondFigure.GetSurfaceArea().ToString(), secondFigure.GetVolume().ToString());
            AnsiConsole.Write(secondTable);
            bool isEqual = _figureRepository.CompareFigures(firstIndex, secondIndex);
            AnsiConsole.WriteLine($"\nFigures with indexes {firstIndex} and {secondIndex} {(isEqual ? "are" : "are not")} equal!\n");
            return 0;
        }
    }
}