using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System;

namespace PromLab01
{
    public class DeleteCommand : Command<DeleteCommand.DeleteCommandSettings>
    {
        public class DeleteCommandSettings : CommandSettings
        {
        }

        private readonly IXmlFigureRepository _figureRepository;

        public DeleteCommand(IXmlFigureRepository figureRepository)
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