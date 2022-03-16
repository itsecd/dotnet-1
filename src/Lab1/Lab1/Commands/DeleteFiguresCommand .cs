using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteFiguresCommand : Command<DeleteFiguresCommand.DeleteFiguresSettings>
    {
        public class DeleteFiguresSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public DeleteFiguresCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFiguresSettings settings)
        {
            var userChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Вы уверены, что хотите удалить все фигуры?")
                .AddChoices("Да", "Нет"));
            if (userChoice == "Да")
                _figuresRepository.DeleteFigures();
            return 0;
        }
    }
}
