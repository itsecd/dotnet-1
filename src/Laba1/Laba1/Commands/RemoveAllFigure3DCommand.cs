using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class RemoveAllFigure3DCommand : Command<RemoveAllFigure3DCommand.RemoveAllFigureSettings>
    {
        public class RemoveAllFigureSettings : CommandSettings
        {

        }
        private readonly IFigures3DRepository _figureRepository;
        public RemoveAllFigure3DCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllFigureSettings settings)
        {
           
            _figureRepository.RemoveAllFigures();
            AnsiConsole.WriteLine("All Figure3D removed!");
            return 0;
        }
    }

 }
