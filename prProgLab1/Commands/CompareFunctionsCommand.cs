using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace prProgLab1.Commands
{
    public class CompareFunctionsCommand : Command<CompareFunctionsCommand.CompareFunctionsSettings>
    {
        public class CompareFunctionsSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public CompareFunctionsCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetAll();
            for (var i = 0; i < functions.Count; i++)
            {
                AnsiConsole.MarkupLine($"[yellow]{i}. {functions[i]}[/]");
            }

            int first;
            int second;
            do
            {
                first = AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите первый индекс: [/]"));
            } while (first > functions.Count);

            do
            {
                second = AnsiConsole.Prompt(new TextPrompt<int>("[green]Введите второй индекс: [/]"));
            } while (second > functions.Count);

            AnsiConsole.Write($"Функции ({functions[first]}) и ({functions[second]}) ");

            if (functions[first].Equals(functions[second]))
                AnsiConsole.Markup("[green] равны[/]");
            else
                AnsiConsole.Markup("[red] не равны[/]");
            return 0;
        }
    }
}