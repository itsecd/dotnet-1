using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintFiguresCommand : Command<PrintFiguresCommand.PrintFiguresCommandSettings>
    {
        public class PrintFiguresCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public PrintFiguresCommand(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintFiguresCommandSettings settings)
        {
            var figure = _figureRepository.GetFigures();
            var table = new Table();
            table.AddColumn("Type Figure");
            table.AddColumn("Coords");
            table.AddColumn("GetSurfaceArea");
            table.AddColumn("GetVolume");
            foreach (var elem in figure)
            {
                table.AddRow(elem.GetType().Name, elem.ToString(), elem.GetSurfaceArea().ToString(), elem.GetVolume().ToString());
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
