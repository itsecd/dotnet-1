using Lab1.Reposity;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintListFigure : Command<FigureCommands.AddFigureCommand>
    {
        public class PrintFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public PrintListFigure(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] FigureCommands.AddFigureCommand settings)
        {
            _figureRepository.PrintScreen();
            return 0;
        }
    }
}
