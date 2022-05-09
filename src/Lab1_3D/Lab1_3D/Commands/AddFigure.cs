using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1_3D.Model;
using Lab1_3D.Repositories;

namespace Lab1_3D.Commands
{
    public class AddFigure : Command<AddFigure.AddFigureSettings>
    {
        public class AddFigureSettings : CommandSettings { }

            private readonly IFigures _figureRepository;
            public AddFigure(IFigures figureRepository)
            {
                _figureRepository = figureRepository;
            }
            public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
            {
                var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Select the figure type:")
                    .AddChoices("Rectangular parallelepiped", "Cylinder", "Sphere"));
                Figure3D figure = figureType switch
                {
                    "Rectangular parallelepiped" => new RectangularParallelepiped(
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]X coordinate for point 1:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]Y coordinate for point 1:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]Z coordinate for point 1:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]X coordinate for point 2:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]Y coordinate for point 2:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[yellow]Z coordinate for point 2:[/]"))
                        ),
                    "Cylinder" => new Cylinder(
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]X coordinate for centre:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Y coordinate for centre:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Z coordinate for centre:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Radius:[/]")
                        .ValidationErrorMessage("[red]Invalid input[/]")
                        .Validate(num => num >= 0)),
                        AnsiConsole.Prompt(new TextPrompt<double>("[blue]Height:[/]")
                        .ValidationErrorMessage("[red]Invalid input[/]")
                        .Validate(num => num >= 0))),
                    "Sphere" => new Sphere(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]X coordinate for centre:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Y coordinate for centre:[/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Z coordinate for centre:[/]")),
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
                int index = AnsiConsole.Prompt(new TextPrompt<int>("[white]Enter the index to insert the shape: [/]")
                   .ValidationErrorMessage("[red]Invalid input[/]")
                   .Validate(ind => (ind >= 0 && ind <= _figureRepository.GetCountFigures())));
                _figureRepository.AddFigure(figure, index);
                return 0;
            }
        }
}
