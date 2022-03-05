using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureSettings>
    {
        public class RemoveFigureSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public RemoveFigureCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            //var figures = _figureRepository.GetList();
            int index = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Введите индекс фигуры для удаления: [/]"));
            _figureRepository.RemoveAt(index);
            return 0;
        }
    }
}
