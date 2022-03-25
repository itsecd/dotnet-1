using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ClearFiguresCommand : Command<ClearFiguresCommand.ClearFiguresCommandSettings>
    {
        public class ClearFiguresCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public ClearFiguresCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext conteXt, [NotNull] ClearFiguresCommandSettings settings)
        {
            _figureRepository.Clear();
            AnsiConsole.MarkupLine("[green]All figures in list deleted [/]");
            return 0;
        }
    }
}
