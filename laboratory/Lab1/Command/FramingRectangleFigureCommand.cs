using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class FramingRectangleFigureCommand : Command<FramingRectangleFigureCommand.FramingRectangleFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public FramingRectangleFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FramingRectangleFigureSettings settings)
        {
            int indexSelectionFigure = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index element 0<=:")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]The index must be greater than zero[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));

            Figure? framingRectangle = _figureRepository?.GetAll()?[indexSelectionFigure].FramingRectangle();
            AnsiConsole.WriteLine(framingRectangle!.ToString());
            var str = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Add a framing rectangle to the collection: [/]")
                .AddChoices("yes", "no"));
            switch (str)
            {
                case "yes":
                    _figureRepository!.Insert(indexSelectionFigure, framingRectangle);
                    break;
                case "no":
                    break;
            }
            return 0;

        }

        public class FramingRectangleFigureSettings : CommandSettings
        {

        }
    }
}
