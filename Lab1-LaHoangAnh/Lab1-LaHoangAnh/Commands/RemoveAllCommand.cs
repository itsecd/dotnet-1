using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveAllCommand : Command<RemoveAllCommand.RemoveAllSettings>
    {
        public class RemoveAllSettings : CommandSettings { }

        private readonly IFigureRepository _figuresRepository;

        public RemoveAllCommand(IFigureRepository figureRepository)
        {
            _figuresRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllSettings settings)
        {
            AnsiConsole.Write("[orange]Контейнер удален.");
            _figuresRepository.RemoveAll();
            return 0;
        }
    }
}
