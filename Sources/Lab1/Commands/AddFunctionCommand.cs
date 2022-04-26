using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class AddFunctionCommand : Command<AddFunctionCommand.AddFunctionSettings>
    {
        public class AddFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public AddFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] AddFunctionSettings settings)
        {
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите вид функции: ")
                .AddChoices("Константа", "Линейная функция", "Квадратичная функция", "Синусоидальная", "Косинусоидальная"));

            switch (functionType)
            {
                case "Линейная функция":
                    {
                        var function = new LinearFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]"))
                            );
                        _functionsRepository.AddFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Иднекс для вставки элемента: [/]")),function);
                        break;
                    }

                case "Квадратичная функция":
                    {
                        var function = new QuadraticFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х^2: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]"))
                            );
                        _functionsRepository.AddFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Иднекс для вставки элемента: [/]")), function);
                        break;
                    }
                case "Синусоидальная":
                    {
                        var function = new SinusFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при sin: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа (фаза): [/]"))
                            );
                        _functionsRepository.AddFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Иднекс для вставки элемента: [/]")), function);
                        break;
                    }
                case "Косинусоидальная":
                    {
                        var function = new CosinusFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при cos: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа (фаза): [/]"))
                            );
                        _functionsRepository.AddFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Иднекс для вставки элемента: [/]")), function);
                        break;
                    }
                case "Константа":
                    _functionsRepository.AddFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Иднекс для вставки элемента: [/]")), 
                            new ConstantFunction(
                                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]"))));
                    break;
            }
            return 0;
        }
    }
}
