using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class TotalVolumeCollectionCommand : Command<TotalVolumeCollectionCommand.TotalVolumeCollectionSettings>
    {
        public class TotalVolumeCollectionSettings : CommandSettings
        {

        }
        private readonly IFigures3DRepository _figureRepository;
        public TotalVolumeCollectionCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] TotalVolumeCollectionSettings settings)
        {
            AnsiConsole.Write(new Markup($"[bold yellow]The total volume of the collection's figures:[/] [white] {_figureRepository.TotalVolume():f3}[/]\n"));
            AnsiConsole.Write(new Markup($"[bold blue]\nThe total volume of the collection's figures (via System.Linq):[/] [white] {_figureRepository.TotalVolumeWithLinq():f3} [/]\n"));
            return 0;
        }
    }
}