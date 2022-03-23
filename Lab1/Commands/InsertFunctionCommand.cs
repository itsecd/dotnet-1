using Lab1.Model;
using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
            var functionFactory = new Dictionary<string, Func<Function>>
            {
                { "Константа",() => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                )},
                {
                "Линейная функция",() => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Linear' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                )},
                {"Квадратичная функция",() => new QuadraticFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Quadratic' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Linear' coefficient :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'constValue' :[/]"))
                )},
                {"Синус",() => new Sin(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Amplitude' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Omega' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Phase' :[/]"))
                )},
                {"Косинус",() => new Cos(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Amplitude' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Omega' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'Phase' :[/]"))
                )},
            };

            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип функции: ")
                .AddChoices(functionFactory.Keys));

            var newFunction = functionFactory[functionType];
            var addFunction = newFunction.Invoke();
            
            int index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Enter index :[/]"));
            _functionsRepository.Insert(index, addFunction);
            return 0;
        }
    }
}
