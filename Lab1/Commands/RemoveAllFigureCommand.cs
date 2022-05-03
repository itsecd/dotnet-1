using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveAllFigureCommand : Command<RemoveAllFigureCommand.RemoveAllFigureSettings>
    {
        public class RemoveAllFigureSettings : CommandSettings
        {

        }
        private readonly IFiguresRepository _figureRepository;
        public RemoveAllFigureCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllFigureSettings settings)
        {

            _figureRepository.Clean();
            AnsiConsole.WriteLine("All figures removed!");
            return 0;
        }
    }
}
