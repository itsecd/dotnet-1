using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.View.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {
        public class AddFigureSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public AddFigureCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            _controller.OpenFile(_controller.StorageFileName);
            var add = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to add?")
                            .AddChoices("Rectangular Cuboid", "Sphere", "Cylinder"));
            int indexAdd = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));
            if (_controller.CheckIndex(indexAdd) || indexAdd == _controller.Figures.Count)
            {
                switch (add)
                {
                    case "Rectangular Cuboid":
                        _controller.AddRectangularCuboid(
                            indexAdd,
                            InputPointCoordinate(),
                            InputPointCoordinate());
                        break;
                    case "Sphere":
                        _controller.AddSphere(
                            indexAdd,
                            InputPointCoordinate(),
                            AnsiConsole.Prompt(new TextPrompt<double>("Radius :")));
                        break;
                    case "Cylinder":
                        _controller.AddCylinder(
                            indexAdd,
                            InputPointCoordinate(),
                            AnsiConsole.Prompt(new TextPrompt<double>("Radius :")),
                            AnsiConsole.Prompt(new TextPrompt<double>("Height :")));
                        break;
                };
            }
            else
            {
                AnsiConsole.Write("Index Error");
                Console.ReadLine();
            }
            _controller.SaveFile(_controller.StorageFileName);
            return 0;
        }

        private Point InputPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate X:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate Y:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate Z:")));
        }
    }
}
