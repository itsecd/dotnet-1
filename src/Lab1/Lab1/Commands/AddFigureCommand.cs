using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {
        public class AddFigureSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public AddFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип фигуры: ")
                .AddChoices("Прямоугольник", "Квадрат"));

            Figure figure = figureType switch
            {
                "Прямоугольник" => new Rectangle(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Точка 1 X[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Точка 1 Y[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Точка 2 X[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Точка 2 Y[/]"))
                ),
                "Квадрат" => new Square(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]X[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Y[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]A[/]"))
                ),
                _ => null
            };

            if (figure == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип фигуры: {figureType}[/]");
                return -1;
            }
            _figuresRepository.AddFigure(figure);
            return 0;
        }
    }
}
