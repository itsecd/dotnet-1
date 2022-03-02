using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System;

namespace PromProg1
{
    public class DeleteCommand : Command<DeleteCommand.DeleteCommandSettings>
    {
        public class DeleteCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository figureRepository;

        public DeleteCommand(IFigureRepository _figureRepository)
        {
            figureRepository = _figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteCommandSettings settings)
        {
            figureRepository.OpenFile(figureRepository.StorageFileName);
            figureRepository.DeleteFigure(AnsiConsole.Prompt(new TextPrompt<int>("Delete Index :")));    
            figureRepository.SaveFile(figureRepository.StorageFileName);
            return 0;
        }
    }
}