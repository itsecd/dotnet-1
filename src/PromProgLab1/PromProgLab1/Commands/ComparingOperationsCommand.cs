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

            var lhsIndexPrompt = new TextPrompt<int>("[lightpink3]Введите индекс первой операции для сравнения: [/]");
            int lhsIndex = AnsiConsole.Prompt(lhsIndexPrompt);

            var rhsIndexPrompt = new TextPrompt<int>("[lightpink3]Введите индекс второй операции для сравнения: [/]");
            int rhsIndex = AnsiConsole.Prompt(rhsIndexPrompt);

            if (operations[lhsIndex].Equals(operations[rhsIndex]))
                AnsiConsole.MarkupLine("[green]Операции равны [/]");
            else
                AnsiConsole.MarkupLine("[red]Операции не равны [/]");
            return 0;
        }
    }
}
