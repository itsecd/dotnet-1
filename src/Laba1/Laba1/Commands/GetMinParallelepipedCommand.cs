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
            var BaseFigure = _figureRepository.GetFigure(figureIndex);
            var BaseTable = new Table();
            BaseTable.AddColumn("Type");
            BaseTable.AddColumn("Info");
            BaseTable.AddColumn("Area");
            BaseTable.AddColumn("Volume");
            BaseTable.AddRow(BaseFigure.GetType().Name, BaseFigure.ToString(),
                              BaseFigure.GetArea().ToString(), BaseFigure.GetVolume().ToString());
            AnsiConsole.Write(BaseTable);
            var table = new Table();
            table.AddColumn("Info");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            var MinFramingParallelepiped = _figureRepository.GetMinFrameParallelepiped(figureIndex);
            table.AddRow( 
                          MinFramingParallelepiped.ToString(),
                          MinFramingParallelepiped.GetArea().ToString(),
                          MinFramingParallelepiped.GetVolume().ToString());
            AnsiConsole.WriteLine($"\nThe minimum framing rectangular parallelepiped " +
                $"for the figure under the index {figureIndex} ");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
