using System.Diagnostics.CodeAnalysis;
using Laba1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Laba1.Commands
{
    public class CompareFigures3DCommand : Command<CompareFigures3DCommand.CompareFiguresSettings>
    {
        public class CompareFiguresSettings : CommandSettings
        {
        }
        private readonly IFigures3DRepository _figureRepository;
        public CompareFigures3DCommand(IFigures3DRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFiguresSettings settings)
        {
            
            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Enter the index of the first figure to compare: [/]")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(num => num >= 0));
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Enter the index of the second figure to compare: [/]")
                .ValidationErrorMessage("[red]Invalid input[/]")
                .Validate(num =>( num >= 0)));
            bool isEqual = _figureRepository.CompareFigures(firstIndex, secondIndex);
            AnsiConsole.WriteLine($"Figures with indexes {firstIndex} and {secondIndex} {(isEqual ? "are" : "are not")} equal ");

            return 0;
        }
    }
}
