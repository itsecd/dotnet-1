using Lab1.Model;
using Lab1.Repositories;
using Lab1.Shapes;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
namespace Lab1.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class AddFigureSettings : CommandSettings { }

        public AddFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            string textMenu = AnsiConsole.Prompt(
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
            _figuresRepository.AddFigure(figure);
            return 0;
        }
    }
}
