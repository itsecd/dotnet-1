using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class PrintAllFigure3DCommand : Command<PrintAllFigure3DCommand.PrintAllFigureSettings>
    {
        public class PrintAllFigureSettings : CommandSettings
        {

        }
        private readonly IFigures3DRepository _figureRepository;
        public PrintAllFigure3DCommand(IFigures3DRepository figureRepository)
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
            table.AddColumn("Area");
            table.AddColumn("Volume");
            for(int i=0; i < _figureRepository.GetCountFigures(); ++i)
            {
                if (i == 10)
                {
                    table.AddRow("...", "...", "...", "...");
                    break;
                }
                table.AddRow(_figureRepository.GetFigures()[i].GetType().Name,
                              _figureRepository.GetFigures()[i].ToString(),
                              _figureRepository.GetFigures()[i].GetArea().ToString(),
                              _figureRepository.GetFigures()[i].GetVolume().ToString());
            }
           
           
            AnsiConsole.Write(table);
           
            double sumV1 = 0;
            foreach (var figure in figures)
            {
                sumV1 += figure.GetVolume();
            }
            AnsiConsole.Write(new Markup($"[bold yellow]The total volume of the collection figures(method #1):[/] [white] {sumV1:f3}[/]"));
            AnsiConsole.WriteLine();
            double sumV2 = 0;
            sumV2 = figures.Sum(figure => figure.GetVolume());
            AnsiConsole.Write(new Markup($"[bold blue]The total volume of the collection figures(method #2):[/] [white] {sumV2:f3} [/]"));
            AnsiConsole.WriteLine();
            return 0;
        }


    }

}
