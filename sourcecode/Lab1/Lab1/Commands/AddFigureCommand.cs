using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureCommandSettings>
    {
        public class AddFigureCommandSettings : CommandSettings
        {

        }

        private readonly IFigureRepository _figureRepository;

        public AddFigureCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext conteXt, [NotNull] AddFigureCommandSettings settings)
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("choice")
                .AddChoices("Rectangular", "Sphere", "Cylinder"));
            Figure figure = choice switch
            {
                "Rectangular" => new Rectangular
                {
                    BaseLeftTop = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 Z [/]"))
                    ),
                    BaseRightBottom = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 Z [/]"))
                    ),
                    Depth = AnsiConsole.Prompt(new TextPrompt<double>("[green]Высота H [/]"))
                },
                "Sphere" => new Sphere
                {
                    Center = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center Z [/]"))
                    ),
                    Radius = AnsiConsole.Prompt(new TextPrompt<double>("[green]Radius [/]"))
                },
                "Cylinder" => new Cylinder
                {
                    Center = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center Z [/]"))
                    ),
                    Radius = AnsiConsole.Prompt(new TextPrompt<double>("[green]Radius [/]")),
                    Height = AnsiConsole.Prompt(new TextPrompt<double>("[green]Height [/]"))
                },
                _ => throw new System.Exception("Invalid Type")
            };
            _figureRepository.Add(figure);
            return 0;
        }
    }
}
