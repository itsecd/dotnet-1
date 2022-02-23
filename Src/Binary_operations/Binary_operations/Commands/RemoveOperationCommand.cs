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
    public class RemoveOperationCommand : Command<RemoveOperationCommand.RemoveOperationSettings>
    {
        public class RemoveOperationSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public RemoveOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveOperationSettings settings)
        {
            var text_delete = new TextPrompt<int>("[blue]Введите индекс операции, которую хотите удалить: [/]");
            int index_delete = AnsiConsole.Prompt(text_delete);
            _operationsRepository.RemoveOperation(index_delete);
            return 0;
        }


    }
}

