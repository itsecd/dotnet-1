using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteFigureCommand : Command<DeleteFigureCommand.DeleteFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class DeleteFigureSettings : CommandSettings { }

        public DeleteFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFigureSettings settings)
        {
            _figuresRepository.PrintScreen();
            int textMenu = AnsiConsole.Ask<int>(" Enter the index of the shape you want to delete");
            AnsiConsole.Clear();
            _figuresRepository.RemoveFigure(textMenu);
            _figuresRepository.PrintScreen();

            return 0;
        }


    }
}
