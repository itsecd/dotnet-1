using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Generic;
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
            List<Figure>? listElements = _figureRepository.GetAll();
            if (listElements!.Count == 0)
            {
                AnsiConsole.Clear();
                AnsiConsole.WriteLine("Comparison is not possible!");
                return 1;
            }
            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Type");
            table.AddColumn("Element");
            table.AddColumn("Square");
            table.AddColumn("Perimeter");
            for (int i = 0; i < listElements.Count; i++)
            {
                table.AddRow(i.ToString(), listElements[i].GetType().Name, listElements[i].ToString(), listElements[i].Area().ToString(), listElements[i].Perimeter().ToString());
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

            AnsiConsole.WriteLine($"{listElements[indexFirst]} == {listElements[indexSecond]}? {listElements[indexFirst].Equals(listElements[indexSecond])}");
            return 0;
        }

        public class ComparisonFigureSettings : CommandSettings
        {

        }
    }
}
