using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class TableCommand : Command<TableCommand.ViewTableSettings>
    {
        public class ViewTableSettings : CommandSettings
        {
        }

        private readonly IFigureRepository _figureRepository;

        public TableCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ViewTableSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            Table table = new();
            AnsiConsole.Write("Entered data:");
            table.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "FramingRectangle");
            for (int indexTable = 0; indexTable < _figureRepository.Figures.Count; indexTable++)
            {
                if (indexTable > 10)
                {
                    table.AddRow("...", "...", "...", "...", "...", "...");
                    break;
                }
                table = AddRowToTable(table, indexTable, _figureRepository.Figures[indexTable]);
                AnsiConsole.WriteLine();
            }
            AnsiConsole.Write(table);
            Console.ReadLine();
            return 0;
        }

        private Table AddRowToTable(Table table, int index, Figure figure)
        {
            table.AddRow(new Markup(index.ToString()),
                new Markup(figure.GetType().Name),
                new Markup("[green]" + figure + "[/]"),
                new Markup("[red]" + figure.Square() + "[/]"),
                new Markup("[yellow]" + figure.Perimeter() + "[/]"),
                new Markup("[blue]" + figure.FramingRectangle() + "[/]"));
            return table;
        }
    }
}