using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class FileCommands : Command<FileCommands.FileCommandSettings>
    {
        public class FileCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository figureRepository;

        public FileCommands(IFigureRepository _figureRepository)
        {
            figureRepository = _figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FileCommandSettings settings)
        {
            var saveOpen = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What you want to do?")
                            .AddChoices("Save As", "Open As"));
            switch (saveOpen)
            {
                case "Save As":
                    AnsiConsole.Write("Path to Save file:\n");
                    string pathSave = Console.ReadLine();
                    figureRepository.SaveFile(pathSave);
                    break;
                case "Open As":
                    AnsiConsole.Write("Path to Open file:\n");
                    string pathOpen = Console.ReadLine();
                    figureRepository.OpenFile(pathOpen);
                    figureRepository.SaveFile(figureRepository.StorageFileName);
                    break;
            };
            return 0;
        }
    }
}