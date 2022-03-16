using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetMinRectangleCommand : Command<GetMinRectangleCommand.GetMinRectangleSettings>
    {
        public class GetMinRectangleSettings : CommandSettings
        {
        }
        private readonly IFiguresRepository _figureRepository;
        public GetMinRectangleCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] GetMinRectangleSettings settings)
        {

            int figureIndex = AnsiConsole.Prompt(new TextPrompt<int>(
                "Enter the index of the shape to find the minimum framing rectangle: ")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var baseFigure = _figureRepository.GetFigure(figureIndex);
            var baseTable = new Table();
            baseTable.AddColumn("Type");
            baseTable.AddColumn("Info");
            baseTable.AddColumn("Perimeter");
            baseTable.AddColumn("Area");
            baseTable.AddRow(baseFigure.GetType().Name, baseFigure.ToString(),
                              baseFigure.GetPerimeter().ToString(), baseFigure.GetArea().ToString());
            AnsiConsole.Write(baseTable);
            var table = new Table();
            table.AddColumn("Info");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            var minRectangle = _figureRepository.GetMinRectangle(figureIndex);
            table.AddRow(
                          minRectangle.ToString(),
                          minRectangle.GetPerimeter().ToString(),
                          minRectangle.GetArea().ToString());
            AnsiConsole.WriteLine($"\nThe minimum framing rectangle " +
                $"for the figure under the index {figureIndex} ");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
