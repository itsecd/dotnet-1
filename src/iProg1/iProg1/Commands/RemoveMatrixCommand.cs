using iProg1.Model;
using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace iProg1.Commands
{
    public class RemoveMatrixCommand : Command<RemoveMatrixCommand.RemoveMatrixSettings>
    {
        public class RemoveMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matrixRepository;
        
        public RemoveMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }
        
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveMatrixSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the matrix to remove(\"-10\" to EXIT): ")
                .ValidationErrorMessage("[red]That's not a valid index[/]")
                .Validate(_matrixRepository.IsIndexInRange));
            if(index == 0 && _matrixRepository.GetCount() == 0)
            {
                return 0;
            }
            if(index == -10)
            {
                return -10;
            }
            _matrixRepository.RemoveMatrix(index);
            return 1;
        }
    }
}
