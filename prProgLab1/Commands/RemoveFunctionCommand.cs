using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace prProgLab1.Commands
{
    public class RemoveFunctionCommand : Command<RemoveFunctionCommand.RemoveFunctionSettings>
    {
        public class RemoveFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public RemoveFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFunctionSettings settings)
        {
            if (_functionsRepository.GetAll().Count == 0)
            {
                AnsiConsole.MarkupLine($"[red]Репозиторий пуст[/]");
                return 0;
            }

            var functionsCount = _functionsRepository.GetAll().Count;

            for (var i = 0; i < functionsCount; i++)
            {
                AnsiConsole.MarkupLine($"[yellow]{i}. {_functionsRepository.GetAll()[i]}[/]");
            }

            int index;
            do
            {
                index = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс для вставки матрицы"));
            } while (index >= _functionsRepository.GetAll().Count);

            _functionsRepository.RemoveAt(index);

            return 0;
        }
    }
}