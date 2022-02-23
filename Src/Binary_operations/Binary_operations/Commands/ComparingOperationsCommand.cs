using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int index_lhs = AnsiConsole.Prompt(text1);

            var text2 = new TextPrompt<int>("[lightpink3]Введите индекс второй операции для сравнения: [/]");
            int index_rhs = AnsiConsole.Prompt(text2);
            if (_operationsRepository.CompareOperations(index_lhs, index_rhs) == true)
                AnsiConsole.MarkupLine("[green]Операции равны [/]");
            else
                AnsiConsole.MarkupLine("[red]Операции не равны [/]");
            return 0;
        }


    }
}
