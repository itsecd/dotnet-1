using Lab1.Model;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public AddFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        private static Point ReadPoint(string name)
        {
            AnsiConsole.WriteLine("Coordinate " + name);
            var x = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Enter a real coordinate X:[/]"));
            var y = AnsiConsole.Prompt(new TextPrompt<double>("[Green]Enter a real coordinate Y:[/]"));
            return new Point(x, y);
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            int index = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index element (0<=):")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]The index must be greater than or equal to zero[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));

            var сhoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Type of object being created: [/]")
                .AddChoices("Rectangle", "Triangle", "Circle"));
            switch (сhoice)
            {
                case "Rectangle":
                    {
                        var a = ReadPoint("A");
                        var b = ReadPoint("B");
                        Figure obj = new Rectangle(a, b);
                        _figureRepository.Insert(index, obj);
                        break;
                    }
                case "Triangle":
                    {
                        var a = ReadPoint("A");
                        var b = ReadPoint("B");
                        var c = ReadPoint("C");
                        var obj = new Triangle(a, b, c);
                        _figureRepository.Insert(index, obj);
                        break;
                    }
                case "Circle":
                    {
                        var a = ReadPoint("Center's");
                        AnsiConsole.WriteLine("Radius Circle");
                        double radius = AnsiConsole.Prompt(
                            new TextPrompt<int>("Radius Circle(0, +Б):")
                                .ValidationErrorMessage("Invalid radius")
                                .Validate(index =>
                                {
                                    return index switch
                                    {
                                        <= 0 => ValidationResult.Error("[red]The Radius must be greater than zero[/]"),
                                        _ => ValidationResult.Success(),
                                    };
                                }));
                        var obj = new Circle(a, radius);
                        _figureRepository.Insert(index, obj);
                        break;
                    }
            }
            return 0;

        }

        public class AddFigureSettings : CommandSettings
        {

        }
    }
}
