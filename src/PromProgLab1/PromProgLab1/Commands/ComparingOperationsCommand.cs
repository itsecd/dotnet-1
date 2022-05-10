using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
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
            var operations = _operationsRepository.GetOperations();

            var text1 = new TextPrompt<int>("[lightpink3]Введите индекс первой операции для сравнения: [/]");
            int indexLhs = AnsiConsole.Prompt(text1);

            var text2 = new TextPrompt<int>("[lightpink3]Введите индекс второй операции для сравнения: [/]");
            int indexRhs = AnsiConsole.Prompt(text2);

            if (operations[indexLhs].Equals(operations[indexRhs]))
                AnsiConsole.MarkupLine("[green]Операции равны [/]");
            else
                AnsiConsole.MarkupLine("[red]Операции не равны [/]");
            return 0;
        }
    }
}
