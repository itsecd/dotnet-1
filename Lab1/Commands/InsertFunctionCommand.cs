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

            Function? addFuncion = figureType switch
            {
                "Константа" => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                ),
                "Линейная функция" => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Linear' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                ),
                "Квадратичная функция" => new QuadraticFunction(
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
            if (addFuncion == null)
            {
                AnsiConsole.MarkupLine($"[green]Unknown function type[/]");
                return -1;
            }

            int index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Enter index :[/]"));
            _functionsRepository.Insert(index, addFuncion);
            return 0;
        }
    } 
}
