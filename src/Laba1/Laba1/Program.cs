using System;
using Laba1.Model;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace Laba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var figure1 = new RectangularParallelepiped(new() { X = 1, Y = 5, Z = 4 }, new() { X = -1, Y = -4, Z = 5 });
            var figure2 = new Sphere(new() { X = -3, Y = -4, Z = -1 }, 3.4);
            var figure3 = new Cylinder(new() { X = 2, Y = 5, Z = 7 }, 2.4, 5.6);
            List<Figure3D> figures = new() { figure1, figure2, figure3 };
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select the shape type:")
                .AddChoices("Rectangular parallelepiped", "Cylinder", "Sphere"));
            Figure3D figureNew = figureType switch
            {
                "Rectangular parallelepiped" => new RectangularParallelepiped(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]X coordinate for point 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Y coordinate for point 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Z coordinate for point 1:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]X coordinate for point 2:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Y coordinate for point 2:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Z coordinate for point 2:[/]"))
                    ),
                "Cylinder" => new Cylinder(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]X coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Y coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Z coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Radius:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Height:[/]"))
                    ),
                "Sphere" => new Sphere(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]X coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Y coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Z coordinate for centre:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Radius:[/]"))
                    ),
                _ => null
            };
            if (figureNew == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown shape type:{figureType} [/]");
            }
            figures.Add(figureNew);

            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Area");
            table.AddColumn("Volume");
            foreach (var figure in figures)
            {
                table.AddRow(figure.GetType().Name, figure.ToString(), figure.GetArea().ToString(), figure.GetVolume().ToString());
            }
            AnsiConsole.Write(table);

            double sumV1 = 0;
            foreach (var figure in figures)
            {
                sumV1 += figure.GetVolume();
            }
            AnsiConsole.Write(new Markup($"[bold yellow]The total volume of the collection figures(method #1):[/] [white] {sumV1:f3}[/]"));
            AnsiConsole.WriteLine();
            double sumV2 = 0;
            sumV2 = figures.Sum(figure => figure.GetVolume());
            AnsiConsole.Write(new Markup($"[bold blue]The total volume of the collection figures(method #2):[/] [white] {sumV2:f3} [/]"));
            AnsiConsole.WriteLine();

        }
    }
}
