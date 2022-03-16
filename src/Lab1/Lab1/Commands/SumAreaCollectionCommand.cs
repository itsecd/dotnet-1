using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class SumAreaCollectionCommand : Command<SumAreaCollectionCommand.SumAreaCollectionSettings>
    {
        public class SumAreaCollectionSettings : CommandSettings
        {

        }
        private readonly IFiguresRepository _figureRepository;
        public SumAreaCollectionCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] SumAreaCollectionSettings settings)
        {
            AnsiConsole.Write(new Markup($"[bold yellow]The total volume of the collection's figures:[/] [white] {_figureRepository.SumArea():f3}[/]\n"));
            AnsiConsole.Write(new Markup($"[bold blue]\nThe total volume of the collection's figures (via System.Linq):[/] [white] {_figureRepository.SumAreaLinq():f3} [/]\n"));
            return 0;
        }
    }
}
