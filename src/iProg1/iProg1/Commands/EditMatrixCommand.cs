using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace iProg1.Commands
{
    public class EditMatrixCommand : Command<EditMatrixCommand.EditMatrixSettings>
    {
        public class EditMatrixSettings : CommandSettings
        {
        }
        
        private readonly IMatrixRepository _matrixRepository;

        public EditMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] EditMatrixSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the matrix to update(\"-10\" to EXIT): ")
                .ValidationErrorMessage("That's not a valid index")
                .Validate(_matrixRepository.IsIndexInRange));
            if (index == -10)
            {
                return -10;
            }
            try
            {
                _matrixRepository.OutputMatrix(index);
                int iIndex = AnsiConsole.Prompt(new TextPrompt<int>("Enter i index of the element to update: ")
                    .ValidationErrorMessage("That's not a valid index")
                    .Validate(num => num >= 0));
                int jIndex = AnsiConsole.Prompt(new TextPrompt<int>("Enter j index of the element to update: ")
                    .ValidationErrorMessage("That's not a valid index")
                    .Validate(num => num >= 0));
                double value = AnsiConsole.Prompt(new TextPrompt<double>($"Enter value of the element({iIndex},{jIndex}) to update: ")
                    .ValidationErrorMessage("That's not a valid value"));
                _matrixRepository.UpdateMatrix(index, iIndex, jIndex, value);
                return 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
    }
}
