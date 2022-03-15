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
                .AddChoices("Треугольник", "Прямоугольник", "Круг"));

            Figure figure = figureType switch
            {
                "Треугольник" => new Triangle(
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 1 координата X:")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 1 координата Y:"))),
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 2 координата X: ")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 2 координата Y: "))),
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 3 координата X: ")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 3 координата Y: ")))
                ),
                "Прямоугольник" => new Rectangle(
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 1 координата X: ")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 1 координата Y: "))),
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 2 координата X: ")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Точка 2 координата Y: ")))
                ),
                "Круг" => new Circle(
                    new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("Центр координата X: ")),
                        AnsiConsole.Prompt(new TextPrompt<double>("Центр координата Y: "))),
                    AnsiConsole.Prompt(new TextPrompt<double>("Радиус: "))
                ),
                _ => null
            };
            var index = AnsiConsole.Prompt<int>(new TextPrompt<int>("Индекс для вставки фигуры:"));
            _figuresRepository.AddFigure(index, figure);
            return 0;
        }
    }
}
