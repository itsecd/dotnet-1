using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;

namespace VolumetricFigures.View.Commands
{
    public class DeleteCommand : Command<DeleteCommand.DeleteCommandSettings>
    {
        public class DeleteCommandSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public DeleteCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteCommandSettings settings)
        {
            _controller.OpenFile(_controller.StorageFileName);
            var delete = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to delete?")
                            .AddChoices("Delete Item", "Delete All"));
            switch (delete)
            {
                case "Delete Item":
                    _controller.DeleteFigure(AnsiConsole.Prompt(new TextPrompt<int>("Delete Index :")));
                    break;
                case "Delete All":
                    _controller.DeleteAll();
                    break;
            };
            _controller.SaveFile(_controller.StorageFileName);
            return 0;
        }
    }
}
