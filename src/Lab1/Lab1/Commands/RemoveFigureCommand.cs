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

        private readonly IFiguresRepository _figuresRepository;

        public RemoveFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            var index = AnsiConsole.Prompt(new TextPrompt<int>("Индекс фигуры, которую нужно удалить:"));
            _figuresRepository.RemoveFigure(index);
            return 0;
        }
    }
}
