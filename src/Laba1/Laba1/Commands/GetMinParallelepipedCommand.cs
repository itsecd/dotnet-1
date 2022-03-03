using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class GetMinParallelepipedCommand : Command<GetMinParallelepipedCommand.GetMinParallelepipedSettings>
    {
        public class GetMinParallelepipedSettings : CommandSettings
        {
        }
        private readonly IFigures3DRepository _figureRepository;
        public GetMinParallelepipedCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] GetMinParallelepipedSettings settings)
        {

            int figureIndex = AnsiConsole.Prompt(new TextPrompt<int>(
                "Enter the index of the shape to find the minimum framing parallelepiped: ")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var baseFigure = _figureRepository.GetFigure(figureIndex);
            var baseTable = new Table();
            baseTable.AddColumn("Type");
            baseTable.AddColumn("Info");
            baseTable.AddColumn("Area");
            baseTable.AddColumn("Volume");
            baseTable.AddRow(baseFigure.GetType().Name, baseFigure.ToString(),
                              baseFigure.GetArea().ToString(), baseFigure.GetVolume().ToString());
            AnsiConsole.Write(baseTable);
            var table = new Table();
            table.AddColumn("Info");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            var minFramingParallelepiped = _figureRepository.GetMinFrameParallelepiped(figureIndex);
            table.AddRow( 
                          minFramingParallelepiped.ToString(),
                          minFramingParallelepiped.GetArea().ToString(),
                          minFramingParallelepiped.GetVolume().ToString());
            AnsiConsole.WriteLine($"\nThe minimum framing rectangular parallelepiped " +
                $"for the figure under the index {figureIndex} ");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
