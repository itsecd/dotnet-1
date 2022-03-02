using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class RemoveFigure3DCommand : Command<RemoveFigure3DCommand.RemoveFigureSettings>
    {
        public class RemoveFigureSettings : CommandSettings
        {

        }
        private readonly IFigures3DRepository _figureRepository;
        public RemoveFigure3DCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("[blue] Enter index of the shape to remove: [/]")
                                   .ValidationErrorMessage("[red]Invalid input[/]")
                                   .Validate(num => num >= 0));
            _figureRepository.RemoveFigure(index);
            return 0;
        }



    }

}
