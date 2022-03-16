using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AddFigureCommand: Command<AddFigureCommand.AddFigureSetting>
    {
        public class AddFigureSetting: CommandSettings 
        { 

        }
        private readonly IFiguresRepository _figureRepository;
        public AddFigureCommand(IFiguresRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSetting settings)
        {
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select the figure type:")
                .AddChoices("Rectangle", "Triangle", "Circle"));
            Figure figure = figureType switch
            {
                "Rectangular parallelepiped" => new Rectangle(
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for point 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for point 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for point 2:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for point 2:[/]"))
                    ),
                "Triangle" => new Triangle(
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for vertex 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for vertex 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for vertex 2:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for vertex 2:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for vertex 3:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for vertex 3:[/]"))
                    ),
                "Sphere" => new Circle(
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[green]Radius:[/]")
                    .ValidationErrorMessage("[red]Invalid input[/]")
                    .Validate(num => num >= 0))),
                _ => null
            };
            if (figure == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown figure type:{figureType} [/]");
                return -1;
            }
            int index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Enter the index to insert the figure: [/]")
               .ValidationErrorMessage("[red]Invalid input[/]")
               .Validate(ind => (ind >= 0 && ind <= _figureRepository.GetCountFigures())));
            _figureRepository.AddFigure(figure, index);
            return 0;
        }
    }
}
