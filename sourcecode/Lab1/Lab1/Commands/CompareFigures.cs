using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareFiguresCommand : Command<CompareFiguresCommand.CompareFiguresCommandSettings>
    {
        public class CompareFiguresCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public CompareFiguresCommand(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }

        public override int Execute([NotNull] CommandContext conteXt, [NotNull] CompareFiguresCommandSettings settings)
        {
            var x = AnsiConsole.Ask<int>("[green]Index 1 = [/]");
            var y = AnsiConsole.Ask<int>("[green]Index 2 = [/]");
            var figures = _figureRepository.GetFigures();
            if (figures[x].Equals(figures[y])) AnsiConsole.MarkupLine("[green]Figure in index 1 = Figure in index 2 [/]");
            else AnsiConsole.MarkupLine("[red]Figure in index 1 != Figure in index 2[/]");
            return 0;
        }
    }
}

