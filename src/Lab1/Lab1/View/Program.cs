using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using Lab1.Model;
using Lab1.Repositories;
using Lab1.Shapes;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Lab1
{
    public class main
    {

        static void Main(string[] args)
        {
            bool flag = true;
            string textMenu;
            var rule = new Rule("[#0eef59]Main menu[/]")
            {
                Style = Style.Parse("#0eef59")
            };
            var table = new Table().Centered();
            AnsiConsole.Write(rule);
            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Volume");
            table.AddColumn("SurfaceArea");
            table.AddColumn("Min. Framing Parallelepiped");
            List<Figure> figureList = new List<Figure>();
            var figuresRepository = new XmlFiguresRepository(); 
            while (flag)
            {
                var mainMenu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Choose your next action: [/]")
                .PageSize(10)
                .AddChoices("Create a shape", "Delete object by index",
                "Delete all objects", "Compare object by index",
                "Output container","Exit"));

                switch (mainMenu)
                {
                    case "Create a shape":
                        textMenu = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Choose a shape type")
                            .PageSize(10)
                            .AddChoices("Ball", "Cylinder",
                            "Rectangular Parallepiped"));
                        Figure figure = textMenu switch
                        {
                            "Ball" => new Ball(new Point(
                             AnsiConsole.Ask<int>("Enter the X coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Y coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Z coordinate"))
                            , AnsiConsole.Ask<int>("Enter the radius of the ball:")),

                            "Cylinder" => new Cylinder(new Point(
                              AnsiConsole.Ask<int>("Enter the X coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Y coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Z coordinate"))
                            , AnsiConsole.Ask<int>("Enter the height of the ball:")
                            , AnsiConsole.Ask<int>("Enter the radius of the ball:")),

                            "Rectangular Parallepiped" => new RectangularParallelepiped(new Point(
                              AnsiConsole.Ask<int>("Enter the X coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Y coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Z coordinate"))
                            , new Point(
                              AnsiConsole.Ask<int>("Enter the X coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Y coordinate:")
                            , AnsiConsole.Ask<int>("Enter the Z coordinate"))),
                            _ => throw new NotImplementedException()
                        };
                        AnsiConsole.Clear();
                        figuresRepository.AddFigure(figure);
                        flag = false;
                        break;

                    case "Exit":
                        flag = false;
                        break;
                }
                figuresRepository.PrintScreen();
            }
            
        }
    }
}
