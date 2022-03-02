using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class CompareFigures3DCommand : Command<CompareFigures3DCommand.CompareFiguresSettings>
    {
        public class CompareFiguresSettings : CommandSettings
        {
        }
        private readonly IFigures3DRepository _figureRepository;
        public CompareFigures3DCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFiguresSettings settings)
        {

            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Enter the index of the first figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var firstFigure = _figureRepository.GetFigure(firstIndex);
            var firstTable = new Table();
            firstTable.AddColumn("Type");
            firstTable.AddColumn("Info");
            firstTable.AddColumn("Area");
            firstTable.AddColumn("Volume");
            firstTable.AddRow(firstFigure.GetType().Name, firstFigure.ToString(),
                              firstFigure.GetArea().ToString(), firstFigure.GetVolume().ToString());
            AnsiConsole.Write(firstTable);
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]\nEnter the index of the second figure to compare: [/]\n")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var secondFigure = _figureRepository.GetFigure(secondIndex);
            var secondTable = new Table();
            secondTable.AddColumn("Type");
            secondTable.AddColumn("Info");
            secondTable.AddColumn("Area");
            secondTable.AddColumn("Volume");
            secondTable.AddRow(secondFigure.GetType().Name, secondFigure.ToString(),
                              secondFigure.GetArea().ToString(), secondFigure.GetVolume().ToString());
            AnsiConsole.Write(secondTable);
            bool isEqual = _figureRepository.CompareFigures(firstIndex, secondIndex);
            AnsiConsole.WriteLine($"\nFigures with indexes {firstIndex} and {secondIndex} {(isEqual ? "are" : "are not")} equal!\n");
            return 0;
        }
    }
}
