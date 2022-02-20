using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;

namespace VolumetricFigures.View.Commands
{
    public class FileCommand : Command<FileCommand.FileCommandSettings>
    {
        public class FileCommandSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public FileCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FileCommandSettings settings)
        {
            var saveOpen = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to do?")
                            .AddChoices("Save As", "Open As"));
            switch (saveOpen)
            {
                case "Save As":
                    AnsiConsole.Write("Path to Save file:\n");
                    string pathSave = Console.ReadLine();
                    _controller.SaveFile(pathSave);
                    break;
                case "Open As":
                    AnsiConsole.Write("Path to Open file:\n");
                    string pathOpen = Console.ReadLine();
                    _controller.OpenFile(pathOpen);
                    _controller.SaveFile(_controller.StorageFileName);
                    break;
            };
            return 0;
        }
    }
}
