using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareFigureCommand : Command<CompareFigureCommand.CompareFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class CompareFigureSettings : CommandSettings { }

        public CompareFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFigureSettings settings)
        {
            _figuresRepository.ReadFile();
            var table = new Table().Centered();
            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Volume");
            table.AddColumn("SurfaceArea");
            table.AddColumn("Min. Framing Parallelepiped");
            for (int index = 0; index < _figuresRepository._figuresList.Count; index++)
            {
                table = DrawingLines(table, _figuresRepository._figuresList[index]);
            }
            AnsiConsole.Write(table);

            int firstFigure = AnsiConsole.Ask<int>(" Enter the first index of the shape you want to compare");
            int secondFigure = AnsiConsole.Ask<int>(" Enter the second index of the shape you want to compare");
            AnsiConsole.Clear();
            if (_figuresRepository.CompareFigure(firstFigure, secondFigure))
            {
                AnsiConsole.WriteLine("The figures are similar");
            }
            else
            {
                AnsiConsole.WriteLine("The figures are nor similar"); 
            }
            return 0;
        }
        private Table DrawingLines(Table table, Figure figure)
        {
            table.AddRow(figure.GetType().Name
                , figure.ToString()
                , figure.GetVolume().ToString()
                , figure.GetSurfaceArea().ToString()
                , figure.GetMinimalFramingParalelepiped().ToString());

            return table;
        }
    }
}
