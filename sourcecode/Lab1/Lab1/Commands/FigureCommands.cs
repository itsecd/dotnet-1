using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class FigureCommands : Command<FigureCommands.AddFigureCommand>
    {
        public class AddFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public FigureCommands (IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureCommand settings)
        {
             var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("choice")
                     .AddChoices("Rectangular", "Sphere", "Cylinder"));
            Figure f = choice switch
            {
                "Rectangular" => new Rectangular {
                    Vertex1 = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 1 Z [/]"))
                    ),
                    Vertex2 = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Точка 2 Z [/]"))
                    ),
                    Height = AnsiConsole.Prompt(new TextPrompt<double>("[green]Высота H [/]"))
                },
                "Sphere" => new Sphere
                {
                    Center = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center 1 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center 1 Z [/]"))
                    ),
                    Radius = AnsiConsole.Prompt(new TextPrompt<double>("[green]Radius [/]"))
                },
                "Cylinder" => new Cylinder
                {
                    center = new Point(
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center X [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center 1 Y [/]")),
                        AnsiConsole.Prompt(new TextPrompt<double>("[green]Center 1 Z [/]"))
                    ),
                    RadiusCylinder = AnsiConsole.Prompt(new TextPrompt<double>("[green]Radius [/]")),
                    HeightCylinder = AnsiConsole.Prompt(new TextPrompt<double>("[green]Height [/]"))
                },
                _ => null
            };
            if (f == null)
            {
                AnsiConsole.Markup("[red]Invalid type[/]");
            }
            _figureRepository.AddFigure(f);
            return 0;
        }
    }
}
