using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveAtCommand : Command<RemoveAtCommand.RemoveAtSettings>
    {
        public class RemoveAtSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public RemoveAtCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAtSettings settings)
        {
            int Index = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Вводите индекс фигура для удаления: [/]"));
            _figureRepository.RemoveAt(Index);
            return 0;
        }
    }
}
