using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;
using VolumetricFigures.Model;

namespace VolumetricFigures.View.Commands
{
    public class CompareCommand : Command<CompareCommand.CompareCommandSettings>
    {
        public class CompareCommandSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public CompareCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareCommandSettings settings)
        {
            _controller.OpenFile(_controller.StorageFileName);
            int index1 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 1:"));
            int index2 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 2:"));
            if (_controller.CheckIndex(index1) && _controller.CheckIndex(index2))
            {
                Table tableEquals = new Table();
                tableEquals.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "Min.Cuboid");
                tableEquals = AddRowToTable(tableEquals, index1, _controller.Figures[index1]);
                tableEquals = AddRowToTable(tableEquals, index2, _controller.Figures[index2]);
                AnsiConsole.Write(tableEquals);
                AnsiConsole.Write("\nSquare biggest in element by index " + _controller.CompareSquare(index1, index2));
                AnsiConsole.Write("\nPerimeter biggest in element by index " + _controller.ComparePerimeter(index1, index2));
                Console.ReadLine();
            }
            else
            {
                AnsiConsole.Write("Index Error");
                Console.ReadLine();
            }
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
