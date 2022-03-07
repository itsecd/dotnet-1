using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class CompareCommand : Command<CompareCommand.CompareCommandSettings>
    {
        public class CompareCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository _figureRepository;

        public CompareCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            int index1 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 1:"));
            int index2 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 2:"));
            if (_figureRepository.CheckIndex(index1) && _figureRepository.CheckIndex(index2))
            {
                Table tableEquals = new Table();
                tableEquals.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "Framing Rectangle");
                tableEquals = AddRowToTable(tableEquals, index1, _figureRepository.Figures[index1]);
                tableEquals = AddRowToTable(tableEquals, index2, _figureRepository.Figures[index2]);
                AnsiConsole.Write(tableEquals);
                AnsiConsole.Write("\nSquare is larger for the element with the index" + _figureRepository.CompareSquare(index1, index2));
                AnsiConsole.Write("\nPerimeter is larger for the element with the index " + _figureRepository.ComparePerimeter(index1, index2));
                Console.ReadLine();
            }
            else
            {
                AnsiConsole.Write("Incorrect index");
                Console.ReadLine();
            }
            return 0;
        }

        private Table AddRowToTable(Table table, int index, Figure figure)
        {
            table.AddRow(new Markup(index.ToString()),
                new Markup(figure.GetType().Name),
                new Markup("[red]" + figure + "[/]"),
                new Markup("[green]" + figure.Square() + "[/]"),
                new Markup("[blue]" + figure.Perimeter() + "[/]"),
                new Markup("[yellow]Framing Rectangle: [/]\n" + figure.FramingRectangle()));
            return table;
        }
    }
}