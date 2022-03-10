using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using laboratory.model;

namespace laboratory.Command
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public AddFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            int index;
            if(FigureRepository.Count() == 0 ) index = 0;
            else { 
                do
                    index = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter index element [{1}, {FigureRepository.Count()}]: [/]"));
                while (index < 1 && index > FigureRepository.Count());
                index--;
            }
            var сhoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Type of object being created: [/]")
                .AddChoices("Rectangle", "Triangle", "Circle"));
            switch (сhoice)
            {
                case "Rectangle":
                    AnsiConsole.WriteLine("Coordinate A");
                    var X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    var Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    var A = new Point(X, Y);
                    AnsiConsole.WriteLine("Coordinate B");
                    X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    var B = new Point(X, Y);
                    Figure obj = new Rectangle(A, B);
                    FigureRepository.Insert(index, obj);
                    break;
                case "Triangle":
                    AnsiConsole.WriteLine("Coordinate A");
                    AnsiConsole.WriteLine("Coordinate A");
                    X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    A = new Point(X, Y);
                    AnsiConsole.WriteLine("Coordinate B");
                    X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    B = new Point(X, Y);
                    AnsiConsole.WriteLine("Coordinate C");
                    X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    var C = new Point(X, Y);
                    obj = new Triangle(A, B, C);
                    FigureRepository.Insert(index, obj);
                    break;
                case "Circle":
                    AnsiConsole.WriteLine("Coordinate Center's");
                    X = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату X:[/]"));
                    Y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Введите вещественную координату Y:[/]"));
                    A = new Point(X, Y);
                    AnsiConsole.WriteLine("Radius Circle");
                    double R;
                    do
                        R = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Radius Circle(0, +Б): [/]"));
                    while (R <= 0);
                    obj = new Circle(A, R);
                    FigureRepository.Insert(index, obj);
                    break;
            }
            return 0;

        }

        public class AddFigureSettings : CommandSettings
        {

        }
    }
}
