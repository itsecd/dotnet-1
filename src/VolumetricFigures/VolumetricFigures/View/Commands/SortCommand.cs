using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;

namespace VolumetricFigures.View.Commands
{
    public class SortCommand : Command<SortCommand.SortCommandSettings>
    {
        public class SortCommandSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public SortCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SortCommandSettings settings)
        {
            _controller.OpenFile(_controller.StorageFileName);
            var sort = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("What to sort?")
                .AddChoices("Square", "Perimeter"));
            switch (sort)
            {
                case "Square":
                    _controller.Figures.Sort((figure1, figure2) =>
                        figure1.GetSquare().CompareTo(figure2.GetSquare()));
                    break;
                case "Perimeter":
                    _controller.Figures.Sort((figure1, figure2) =>
                        figure1.GetPerimeter().CompareTo(figure2.GetPerimeter()));
                    break;
            };
            _controller.SaveFile(_controller.StorageFileName);
            return 0;
        }
    }
}
