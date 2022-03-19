using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public RemoveFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            var elements = _figureRepository.GetAll();
            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Type");
            table.AddColumn("Element");
            table.AddColumn("Square");
            table.AddColumn("Perimeter");
            for (int i = 0; i < elements.Count; i++)
            {
                table.AddRow(i.ToString(), elements[i].GetType().Name, elements[i].ToString(), elements[i].Area().ToString(), elements[i].Perimeter().ToString());
            }
            AnsiConsole.Write(table);
            var сhoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Remove: [/]")
                .AddChoices("One element", "All elements"));
            switch (сhoice)
            {
                case "One element":
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
                    FigureRepository.RemoveAt(index);
                    break;
                case "All elements":
                    FigureRepository.Clear();
                    break;
            }
            return 0;
        }

        public class RemoveFigureSettings : CommandSettings
        {

        }
    }
}
