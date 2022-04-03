using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PerimeterFigureCommand : Command<PerimeterFigureCommand.PerimeterFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public PerimeterFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PerimeterFigureSettings settings)
        {
            var listElements = _figureRepository.GetAll();
            if (listElements.Count == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            var index = AnsiConsole.Prompt(
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
            AnsiConsole.WriteLine($"{listElements[index]} Perimeter = {listElements[index].Perimeter()}");
            return 0;
        }

        public class PerimeterFigureSettings : CommandSettings
        {

        }
    }
}