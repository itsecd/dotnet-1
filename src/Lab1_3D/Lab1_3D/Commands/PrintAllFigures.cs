using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using Lab1_3D.Repositories;

namespace Lab1_3D.Commands
{
    public class PrintAllFigure : Command<PrintAllFigure.PrintAllFigureSettings>
    {
        public class PrintAllFigureSettings : CommandSettings
        {

        }
        private readonly IFigures _figureRepository;
        public PrintAllFigure(IFigures figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] PrintAllFigureSettings settings)
        {
            var figures = _figureRepository.GetFigures();
            var table = new Table();
            table.Title("[aqua]3D Figures [/]");
            table.AddColumn("Type");
            table.AddColumn("Info");
            table.AddColumn("SurfaceArea");
            table.AddColumn("Volume");
            for (int i = 0; i < _figureRepository.GetCountFigures(); ++i)
            {
                if (i == 10)
                {
                    table.AddRow("...", "...", "...", "...");
                    break;
                }
                table.AddRow(figures[i].GetType().Name, figures[i].ToString(),
                             figures[i].GetSurfaceArea().ToString(), figures[i].GetVolume().ToString());
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
