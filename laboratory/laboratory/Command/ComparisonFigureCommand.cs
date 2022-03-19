using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ComparisonFigureCommand : Command<ComparisonFigureCommand.ComparisonFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public ComparisonFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComparisonFigureSettings settings)
        {
            if (_figureRepository.GetAll() == null)
            {
                AnsiConsole.Clear();
                AnsiConsole.WriteLine("Comparison is not possible!");
                return 1;
            }
            var elements = _figureRepository.GetAll();
            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Type");
            table.AddColumn("Element");
            table.AddColumn("Square");
            table.AddColumn("Perimeter");
            for(int i = 0; i < elements.Count; i++)
            {
                table.AddRow(i.ToString(), elements[i].GetType().Name, elements[i].ToString(), elements[i].Area().ToString(), elements[i].Perimeter().ToString());
            }
            AnsiConsole.Write(table);
            int indexFirst = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index element (0<=):")
                .ValidationErrorMessage("Invalid index entered")
                    .Validate(index =>
                    {
                        return index switch
                        {
                            < 0 => ValidationResult.Error("[red]The index must be greater than zero[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            int indexSecond = AnsiConsole.Prompt(
              new TextPrompt<int>("Enter index element (0<=):")
              .ValidationErrorMessage("Invalid index entered")
                  .Validate(index =>
                  {
                      return index switch
                      {
                          < 0 => ValidationResult.Error("[red]The index must be greater than zero[/]"),
                          _ => ValidationResult.Success(),
                      };
                  }));

            AnsiConsole.WriteLine($"{elements[indexFirst]} == {elements[indexSecond]}? {elements[indexFirst].Equals(elements[indexSecond])}");
            return 0;
        }

        public class ComparisonFigureSettings : CommandSettings
        {

        }
    }
}
