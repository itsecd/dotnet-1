using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AreaFigureCommand : Command<AreaFigureCommand.AreaFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public AreaFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AreaFigureSettings settings)
        {
            var listElements = _figureRepository.GetAll();
            if (listElements.Count == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            int index = AnsiConsole.Prompt(
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
            AnsiConsole.WriteLine($"{listElements[index]} square = {listElements[index].Area()}");
            return 0;
        }

        public class AreaFigureSettings : CommandSettings
        {

        }
    }
}
