using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteFigureCommand : Command<DeleteFigureCommand.DeleteFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class DeleteFigureSettings : CommandSettings { }

        public DeleteFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFigureSettings settings)
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

            int textMenu = AnsiConsole.Ask<int>(" Enter the index of the shape you want to delete");
            _figuresRepository.RemoveFigure(textMenu);
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
