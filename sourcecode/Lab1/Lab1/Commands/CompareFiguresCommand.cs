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

        public CompareFiguresCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext conteXt, [NotNull] CompareFiguresCommandSettings settings)
        {
            var firstIndex = AnsiConsole.Ask<int>("[green]First Index = [/]");
            var secondIndex = AnsiConsole.Ask<int>("[green]Second Index = [/]");
            var figures = _figureRepository.GetFigures();
            if (figures[firstIndex].Equals(figures[secondIndex])) AnsiConsole.MarkupLine("[green]Figure in first index = Figure in second index [/]");
            else AnsiConsole.MarkupLine("[red]Figure in first index != Figure in second index [/]");
            return 0;
        }
    }
}

