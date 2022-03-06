using System;
using System.Threading;
using Spectre.Console;

namespace PromLab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = 0;
            string f;
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");
            var table = new Table().Centered();
            AnsiConsole.Write(rule);
            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Area");
            table.AddColumn("Perimeter");

            while (a != -1)
            {
                var figure = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                .PageSize(10)
                .AddChoices(new[] {
                "Rectangle", "Circle", "Triangle",
                "Calculate total area", "Extract", "Exit"
                }));
                switch (figure)
                {
                    case "Rectangle":
                        f = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                            .PageSize(10)
                            .AddChoices(new[] {
                        "Two points", "One point and length"
                            }));
                        var rect = f switch
                        {
                            "Two points" => new Rectangle(new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                                new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: "))),
                            "One point and length" => new Rectangle(new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                                AnsiConsole.Ask<double>("Type [green]length[/] of a rectangle side: ")),
                            _ => new Rectangle()
                        };
                        AnsiConsole.Clear();
                        table.AddRow("Rectangle", rect.ToString(), rect.GetArea().ToString(), rect.GetPerimeter().ToString());
                        AnsiConsole.Write(table);
                        break;

                    case "Circle":
                        f = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                            .PageSize(10)
                            .AddChoices(new[] {
                        "Two points", "One point and radius"
                            }));
                        var circ = f switch
                        {
                            "Two points" => new Circle(new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                                new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: "))),
                            "One point and radius" => new Circle(new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                                AnsiConsole.Ask<double>("Type [green]radius[/] of a circle: ")),
                            _ => new Circle()
                        };
                        AnsiConsole.Clear();
                        table.AddRow("Circle", circ.ToString(), circ.GetArea().ToString(), circ.GetPerimeter().ToString());
                        AnsiConsole.Write(table);
                        break;

                    case "Triangle":
                        var triangle = new Triangle(new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]third[/] point [green]X[/]: "),
                                AnsiConsole.Ask<double>("Type [green]third[/] point [green]Y[/]: ")));
                        table.AddRow("Triangle", triangle.ToString(), triangle.GetArea().ToString(), triangle.GetPerimeter().ToString());
                        AnsiConsole.Clear();
                        AnsiConsole.Write(table);
                        break;

                    case "Extract":
                        break;

                    case "Exit":
                        a = -1;
                        break;

                    default:
                        break;
                }
            }
            return;
        }
    }
}
