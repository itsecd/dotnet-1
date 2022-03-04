//using Microsoft.Extensions.CommandLineUtils;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    internal class Program
    {
        static void Main()
        {
            FigureRepository figureRepository= new FigureRepository();
            // figureRepository.AddFigure();
            // var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>().Title)
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                               .Title("What to add?")
                               .AddChoices("Rectangle", "Circle", "Triangle"));
            Figure figure = figureType switch
            {
                "Rectangle" => new Rectangle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X2 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y2 :")))
                    ),
                 "Circle" => new Circle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
                    AnsiConsole.Prompt(new TextPrompt<double>("Radius :"))),

                  "Triangle" => new Triangle(
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
                    new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X2 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y2 :"))),
                     new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X3 :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Точка Y3 :")))),
                    _ => null
            };
            if(figure == null)
            {
                AnsiConsole.MarkupLine("Неизвестный тип фигуры: {figureType}[/]");
            }
            figureRepository.AddFigure(figure);
            //var table = new Table();
            //table.AddColumn("Type");
            //table.AddColumn("Coordinate");

        }
    }
}
