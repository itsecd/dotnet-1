using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using Lab1_3D.Repositories;

namespace Lab1_3D.Commands
{
    public class DeleteAllFigures : Command<DeleteAllFigures.DeleteAllFiguresSettings>
    {
        public class DeleteAllFiguresSettings : CommandSettings
        {

        }
        private readonly IFigures _figureRepository;
        public DeleteAllFigures(IFigures figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllFiguresSettings settings)
        {

            _figureRepository.DeleteAllFigures();
            AnsiConsole.WriteLine("All figures deleted!");
            return 0;
        }
    }
}
