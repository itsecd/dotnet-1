using System;
using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class RemoveOperationCommand : Command<RemoveOperationCommand.RemoveOperationSettings>
    {
        public class RemoveOperationSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public RemoveOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveOperationSettings settings)
        {

            AnsiConsole.MarkupLine("Введите индекс удаляемой операции\n");
            int index;
            string strIndex = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(strIndex, out index))
                {
                    _operationsRepository.RemoveOperation(index);
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный индекс не является числом\n");
                }
            }

            return 0;
        }
    }
}
