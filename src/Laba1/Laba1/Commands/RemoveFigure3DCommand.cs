using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class RemoveFigure3DCommand : Command<RemoveFigure3DCommand.RemoveFigureSettings>
    {
        public class RemoveFigureSettings : CommandSettings
        {

        }
        private readonly IFigures3DRepository _figureRepository;
        public RemoveFigure3DCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the shape to remove: \n")
                                   .ValidationErrorMessage("[red]Invalid input[/]")
                                   .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var figure = _figureRepository.GetFigure(index);
            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Info");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            table.AddRow(figure.GetType().Name, figure.ToString(),
                              figure.GetArea().ToString(), figure.GetVolume().ToString());
            AnsiConsole.Write(table);
            _figureRepository.RemoveFigure(index);
            AnsiConsole.WriteLine($"\n3D Figure with index {index} removed from collection!\n");
            return 0;
        }
    }
}
