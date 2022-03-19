using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class PrintFigureCommand : Command<PrintFigureCommand.PrintFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public PrintFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintFigureSettings settings)
        {
            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Element");
            table.AddColumn("Square");
            table.AddColumn("Perimeter");
            foreach (var obj in FigureRepository.GetAll())
            {
                table.AddRow(obj.GetType().Name, obj.ToString(), obj.Area().ToString(), obj.Perimeter().ToString());
                if (table.Rows.Count() == 10)
                {
                    table.AddRow("...", "...", "...", "...");
                    break;
                }
            }
            AnsiConsole.Write(table);
            return 0;
        }

        public class PrintFigureSettings : CommandSettings
        {

        }
    }
}
