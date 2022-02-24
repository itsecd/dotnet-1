using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace iProg1.Commands
{
    public class CompareMatrixCommand : Command<CompareMatrixCommand.CompareMatrixSettings>
    {
        public class CompareMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matrixRepository;
        
        public CompareMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareMatrixSettings settings)
        {
            int firstIndex = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the first matrix to compare(\"-10\" to EXIT): ")
                .ValidationErrorMessage("[red]That's not a valid index[/]")
                .Validate(_matrixRepository.IsIndexInRange));
            int secondIndex = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the second matrix to compare(\"-10\" to EXIT): ")
                .ValidationErrorMessage("[red]That's not a valid index[/]")
                .Validate(_matrixRepository.IsIndexInRange));
            if (firstIndex == -10)
            {
                return -10;
            }
            bool isEqual  = _matrixRepository.Compare(firstIndex, secondIndex);
            var rule = new Rule("RESULT").RuleStyle("yellow dim");
            AnsiConsole.Write(rule);
            if (isEqual)
            {
                AnsiConsole.WriteLine($"Matrices {firstIndex} and {secondIndex} are equal");
            }
            else
            {
                AnsiConsole.WriteLine($"Matrices {firstIndex} and {secondIndex} are not equal");

            }
            AnsiConsole.Write(rule);

            return 1;
        }
    }
}
