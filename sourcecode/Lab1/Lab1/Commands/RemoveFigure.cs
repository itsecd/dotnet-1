using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureCommandSettings>
    {
        public class RemoveFigureCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public RemoveFigureCommand(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureCommandSettings settings)
        {
            var index = AnsiConsole.Ask<int>("[green]Index = [/]");
            _figureRepository.RemoveAt(index);
            return 0;
        }
    }
}
