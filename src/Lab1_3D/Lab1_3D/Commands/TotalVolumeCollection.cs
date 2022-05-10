using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using Lab1_3D.Repositories;

namespace Lab1_3D.Commands
{
    public class TotalVolumeCollection : Command<TotalVolumeCollection.TotalVolumeCollectionSettings>
    {
        public class TotalVolumeCollectionSettings : CommandSettings
        {

        }
        private readonly IFigures _figureRepository;
        public TotalVolumeCollection(IFigures figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] TotalVolumeCollectionSettings settings)
        {
            AnsiConsole.Write(new Markup($"[fuchsia]The total volume of the collection's figures:[/] [white] {_figureRepository.TotalVolume():f3}[/]\n"));
            AnsiConsole.Write(new Markup($"[fuchsia]\nThe total volume of the collection's figures (via System.Linq):[/] [white] {_figureRepository.TotalVolumeWithLinq():f3} [/]\n"));
            return 0;
        }
    }
}
