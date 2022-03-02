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
                "[white]Enter the index of the shape to find the minimum framing parallelepiped: [/]")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(num => num >= 0));
            var table = new Table();
            table.AddColumn("Info");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            var MinFramingParallelepiped = _figureRepository.GetMinFrameParallelepiped(figureIndex);
            table.AddRow( 
                          MinFramingParallelepiped.ToString(),
                          MinFramingParallelepiped.GetArea().ToString(),
                          MinFramingParallelepiped.GetVolume().ToString());
            AnsiConsole.WriteLine($"\nThe minimum framing rectangular parallelepiped for the figure under the index {figureIndex} ");
            AnsiConsole.Write(table);
            

            return 0;
        }

        
    }
}
