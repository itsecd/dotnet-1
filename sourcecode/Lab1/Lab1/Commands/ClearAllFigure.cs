using Lab1.Reposity;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ClearAllFigure : Command<ClearAllFigure.ClearAllCommand>
    {
        public class ClearAllCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public ClearAllFigure(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearAllCommand settings)
        {
            _figureRepository.ClearAllFigure();
            return 0;
        }
    }
}
