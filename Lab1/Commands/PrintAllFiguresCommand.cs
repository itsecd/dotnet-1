using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintAllFiguresCommand: Command<PrintAllFiguresCommand.PrintAllFigureSettings>
    {
        public class PrintAllFigureSettings : CommandSettings
        {

        }
        private readonly IFiguresRepository _figureRepository;
        public PrintAllFiguresCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] PrintAllFigureSettings settings)
        {
            var figures = _figureRepository.GetFigures();
            var table = new Table();
            table.Title("[blue] Figures [/]");
            table.AddColumn("Index");
            table.AddColumn("Type");
            table.AddColumn("Info");
            table.AddColumn("Perimeter");
            table.AddColumn("Area");
            for (int i = 0; i < _figureRepository.GetCountFigures(); ++i)
            {
                if (i == 10)
                {
                    table.AddRow("...", "...", "...", "...");
                    break;
                }
                table.AddRow(i.ToString(), figures[i].GetType().Name, figures[i].ToString(),
                             figures[i].GetPerimeter().ToString(), figures[i].GetArea().ToString());
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
