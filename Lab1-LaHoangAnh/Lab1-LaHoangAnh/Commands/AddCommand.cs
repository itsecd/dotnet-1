using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;


namespace Lab1.Commands
{
    public class AddCommand : Command<AddCommand.AddSettings>
    {
        public class AddSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public AddCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddSettings settings)
        {
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Выберите тип фигуры: ").AddChoices("Прямоугольник", "Треугольник", "Круг"));
            Figure? figure = figureType switch
            {
                "Прямоугольник" => new Rectangle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Лево-верхняя вершина X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Лево-верхняя вершина Y = [/]"))),
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Право-нижняя вершина X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Право-нижняя вершина Y = [/]")))
                    ),
                "Треугольник" => new Triangle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая вершина X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая вершина Y = [/]"))),
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая вершина X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая вершина Y = [/]"))),
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья вершина X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья вершина Y = [/]")))
                    ),
                "Круг" => new Circle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Центр X = [/]")), AnsiConsole.Prompt(new TextPrompt<double>("[red]Центр Y = [/]"))),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Радиус = [/]"))
                    ),
                _ => null
            };
            if (figure == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип фигуры: {figureType}[/]");
                return -1;
            }
            else
            {
                _figureRepository.Add(figure);
            }
            return 0;
        }
    }
}
