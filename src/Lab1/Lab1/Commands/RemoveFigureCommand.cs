using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureSettings>
    {
        public class RemoveFigureSettings : CommandSettings
        {

        }
        private readonly IFiguresRepository _figureRepository;
        public RemoveFigureCommand(IFiguresRepository figureRepository)
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
            table.AddColumn("Perimeter");
            table.AddColumn("Area");
            table.AddRow(figure.GetType().Name, figure.ToString(),
                              figure.GetPerimeter().ToString(), figure.GetArea().ToString());
            AnsiConsole.Write(table);
            _figureRepository.RemoveFigure(index);
            AnsiConsole.WriteLine($"\nFigure with index {index} removed from collection!\n");
            return 0;
        }
    }
}
