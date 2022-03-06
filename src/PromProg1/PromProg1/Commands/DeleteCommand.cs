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

        private readonly IFigureRepository _figureRepository;

        public DeleteCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            _figureRepository.DeleteFigure(AnsiConsole.Prompt(new TextPrompt<int>("Delete Index :")));
            _figureRepository.SaveFile(_figureRepository.StorageFileName);
            return 0;
        }
    }
}