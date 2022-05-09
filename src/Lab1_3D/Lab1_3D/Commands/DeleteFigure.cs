using System.Diagnostics.CodeAnalysis;
using Lab1_3D.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1_3D.Commands
{
    public class DeleteFigure : Command<DeleteFigure.DeleteFigureSettings>
    {
        public class DeleteFigureSettings : CommandSettings
        {

        }
        private readonly IFigures _figureRepository;
        public DeleteFigure(IFigures figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFigureSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the shape to delete: \n")
                                   .ValidationErrorMessage("[red]Invalid input[/]")
                                   .Validate(ind => (ind >= 0 && ind < _figureRepository.GetCountFigures())));
            var figure = _figureRepository.GetFigure(index);
            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Info");
            table.AddColumn("SurfaceArea");
            table.AddColumn("Volume");
            table.AddRow(figure.GetType().Name, figure.ToString(),
                              figure.GetSurfaceArea().ToString(), figure.GetVolume().ToString());
            AnsiConsole.Write(table);
            _figureRepository.DeleteFigure(index);
            AnsiConsole.WriteLine($"\n3D Figure with index {index} deleted from collection!\n");
            return 0;
        }
    }
}