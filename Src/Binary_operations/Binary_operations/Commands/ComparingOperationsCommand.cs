using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Binary_operations.Commands
{
    public class ComparingOperationsCommand : Command<ComparingOperationsCommand.ComparingOperationsCommandSettings>

    {
        public class ComparingOperationsCommandSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public ComparingOperationsCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] ComparingOperationsCommandSettings settings)
        {
            var text1 = new TextPrompt<int>("[lightpink3]Введите индекс первой операции для сравнения: [/]");
            int indexLhs = AnsiConsole.Prompt(text1);

            var text2 = new TextPrompt<int>("[lightpink3]Введите индекс второй операции для сравнения: [/]");
            int indexRhs = AnsiConsole.Prompt(text2);
            if (_operationsRepository.CompareOperations(indexLhs, indexRhs) == true)
                AnsiConsole.MarkupLine("[green]Операции равны [/]");
            else
                AnsiConsole.MarkupLine("[red]Операции не равны [/]");
            return 0;
        }


    }
}
