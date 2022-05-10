using prProgLab1.Model;
using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace prProgLab1.Commands
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

            Function func = functionType switch
            {
                "Константа" => new Const(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите значеие константы:[/]"))
                ),
                "Линейная функция" => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'k' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'b' :[/]"))
                ),
                "Квадратичная функция" => new QuadraticFunction(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'a' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'b' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'c' :[/]"))
                ),
                "Синус" => new Sin(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'x' :[/]"))
                ),
                "Косинус" => new Cos(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'x' :[/]"))
                ),
                _ => null
            };

            if (func == null)
            {
                AnsiConsole.MarkupLine("[red]Неизвестный тип[/]");
                return -1;
            }

            if (!_functionsRepository.GetAll().Any())
            {
                _functionsRepository.Insert(-1, func);
                return 0;
            }

            var functionsCount = _functionsRepository.GetAll().Count;

            for (var i = 0; i < functionsCount; i++)
            {
                AnsiConsole.MarkupLine($"[yellow]{i}. {_functionsRepository.GetAll()[i].ToString()}[/]");
            }

            int index = -1;
            do
            {
                index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Индекс, после которого будет вставлена функция:[/]"));
            } while (index > functionsCount || index < 0);
            
            _functionsRepository.Insert(index, func);
            return 0;
        }
    }
}