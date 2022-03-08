using Lab1.Repository;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareTwoFigure : Command<CompareTwoFigure.CompareFigureCommand>
    {
        public class CompareFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public CompareTwoFigure(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }

        public bool CompareFigure(int x, int y)
        {
            var figure = _figureRepository.getFigure();
            for (var i = 0; i < figure.Count; i++)
            {
                if (figure[x].GetType() == typeof(Rectangular) && figure[y].GetType() == typeof(Rectangular))
                {
                    return figure[x].Equals(figure[y]);
                }
                if (figure[x].GetType() == typeof(Sphere) && figure[y].GetType() == typeof(Sphere))
                {
                    return figure[x].Equals(figure[y]);
                }
                if (figure[x].GetType() == typeof(Cylinder) && figure[y].GetType() == typeof(Cylinder))
                {
                    return figure[x].Equals(figure[y]);
                }
            }
            return false;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFigureCommand settings)
        {
            var x = AnsiConsole.Ask<int>("[green]Index 1 = [/]");
            var y = AnsiConsole.Ask<int>("[green]Index 2 = [/]");
            bool z = CompareFigure(x, y);
            if (z == true) AnsiConsole.MarkupLine("[green]Figure in index 1 = Figure in index 2 [/]");
            else AnsiConsole.MarkupLine("[red]Figure in index 1 != Figure in index 2[/]");
            return 0;
        }
    }
}
