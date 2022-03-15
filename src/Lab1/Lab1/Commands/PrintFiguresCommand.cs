using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintFiguresCommand : Command<PrintFiguresCommand.PrintFiguresSettings>
    {
        public class PrintFiguresSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public PrintFiguresCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintFiguresSettings settings)
        {
            var table = new Table();

            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Perimeter");
            table.AddColumn("Area");
            table.AddColumn("MinFramingRectangle");

            int index = 0;
            foreach (Figure figure in _figuresRepository.GetFigures())
            {
                if (index == 10)
                {
                    table.AddRow("...");
                    break;
                }

                table.AddRow(figure.GetType().Name, figure.ToString(), figure.GetPerimeter().ToString(),
                    figure.GetArea().ToString(), figure.GetMinFramingRectangle().ToString());
                ++index;
            }
            table.Centered();
            AnsiConsole.Write(table);
            return 0;
        }
    }
}

