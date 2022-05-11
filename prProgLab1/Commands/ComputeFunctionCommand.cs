using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace prProgLab1.Commands
{
    public class ComputeFunctionCommand : Command<ComputeFunctionCommand.ComputeFunctionSettings>
    {
        public class ComputeFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public ComputeFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComputeFunctionSettings settings)
        {
            var functions = _functionsRepository.GetAll();
            for (var i = 0; i < functions.Count; i++)
            {
                AnsiConsole.MarkupLine($"[yellow]{i}. {functions[i]}[/]");
            }
            int index;
            do
            {
                index = AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите индекс: [/]"));
            } while (index > functions.Count);

            int x = AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите 'x' :[/]"));
            AnsiConsole.MarkupLine($"Значение функции [yellow]{functions[index]}[/] с заданным аргументом = [green]{functions[index].GetValue(x)}[/]");

            return 0;
        }
    }
}