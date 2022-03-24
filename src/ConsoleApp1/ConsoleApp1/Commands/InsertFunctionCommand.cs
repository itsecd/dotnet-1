using ConsoleApp1.Model;
using ConsoleApp1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1.Commands
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
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип функции: ")
                .AddChoices("Константа", "Линейная функция", "Квадратичная функция", "Синус", "Косинус"));

            Func addFunction = functionType switch
            {
                "Константа" => new Constanta(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                ),
                "Линейная функция" => new LinearFunc(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Linear' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                ),
                "Квадратичная функция" => new QuadrFunc(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Quadratic' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Linear' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                ),
                "Синус" => new Sin(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Amplitude' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Omega' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Phase' :[/]"))
                ),
                "Косинус" => new Cos(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Amplitude' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Omega' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Phase' :[/]"))
                ),
                _ => null
            };
            if (addFunction == null)
            {
                AnsiConsole.MarkupLine("[yellow]Unknown function type[/]");
                return -1;
            }

            int index = AnsiConsole.Prompt(new TextPrompt<int>("[yellow]Enter index :[/]"));
            _functionsRepository.Insert(index, addFunction);
            return 0;
        }
    }
}