using Lab1.Repository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintListFigure : Command<FigureCommands.AddFigureCommand>
    {
        public class PrintFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public PrintListFigure(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] FigureCommands.AddFigureCommand settings)
        {
            var figure = _figureRepository.getFigure();
            var table = new Table();
            table.AddColumn("Type Figure");
            table.AddColumn("Coords");
            table.AddColumn("SurfaceArea");
            table.AddColumn("Volume");
            foreach (var elem in figure)
            {
                table.AddRow(elem.GetType().Name, elem.ToString(), elem.SurfaceArea().ToString(), elem.volume().ToString());
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
