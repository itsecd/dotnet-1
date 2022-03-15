using Spectre.Console.Cli;
using Lab1.Services;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Lab1.Model;

namespace Lab1.Commands
{
    public class InsertFunctionCommand : Command<InsertFunctionCommand.InsertFunctionSettings>
    {
        public class InsertFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public InsertFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertFunctionSettings settings)
        {
            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип функции: ")
                .AddChoices("Константа", "Линейная функция", "Квадратичная функция", "Синус", "Косинус"));

            Function addFuncion = figureType switch
            {
                "Константа" => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter value 'c' :[/]"))
                ),
                "Линейная функция" => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'k' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]"))
                ),
                "Квадратичная функция" => new QuadraticFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'a' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'c' :[/]"))
                ),
                "Синус" => new Sin(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'a' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'c' :[/]"))
                ),
                "Косинус" => new Cos(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'a' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'c' :[/]"))
                ),
                _ => null
            };
            if (addFuncion == null)
            {
                AnsiConsole.MarkupLine($"[green]Неизвестный тип функции[/]");
                return -1;
            }
            _functionsRepository.Insert(0, addFuncion);

            return 0;
        }
    } 
}
