using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    class GetSumAreaCommand : Command<GetSumAreaCommand.GetSumAreaCommandSettings>
    {
        public class GetSumAreaCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public GetSumAreaCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetSumAreaCommandSettings settings)
        {
            var figures = _figureRepository.GetFigures();
            var sumArea = figures.Sum(figure => figure.GetSurfaceArea());
            AnsiConsole.MarkupLine($"[green]Sum Area: {sumArea}[/]");
            return 0;
        }
    }
}
