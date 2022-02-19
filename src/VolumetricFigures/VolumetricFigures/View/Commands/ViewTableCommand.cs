using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;
using VolumetricFigures.Model;

namespace VolumetricFigures.View.Commands
{
    public class ViewTableCommand : Command<ViewTableCommand.ViewTableSettings>
    {
        public class ViewTableSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public ViewTableCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ViewTableSettings settings)
        {
            Table table = new Table();
            table.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "Min.Cuboid");
            for (int indexTable = 0; indexTable < _controller.Figures.Count; indexTable++)
            {
                if (indexTable > 10)
                {
                    table.AddRow("...", "...", "...", "...", "...", "...");
                    break;
                }
                table = AddRowToTable(table, indexTable, _controller.Figures[indexTable]);
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
                new Markup("[red]" + figure + "[/]"),
                new Markup("[blue]" + figure.GetSquare() + "[/]"),
                new Markup("[blue]" + figure.GetPerimeter() + "[/]"),
                new Panel("[green]Сuboid: [/]\n" + figure.GetMinCuboid()));
            return table;
        }
    }
}
