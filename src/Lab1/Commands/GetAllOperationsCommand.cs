using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class GetAllOperationsCommand : Command<GetAllOperationsCommand.GetAllOperationsSettings>
    {

        public class GetAllOperationsSettings : CommandSettings
        {
        }

        private readonly IOperationsRepository _operationsRepository;

        public GetAllOperationsCommand(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllOperationsSettings settings)
        {
            var operations = _operationsRepository.GetAllOperations();

            var table = new Table();
            table.AddColumn("Тип операции");

            for (var i = 0; i < operations.Count; ++i)
            {
                if (i == 10)
                {
                    table.AddRow("...");
                    break;
                }
                table.AddRow($"{operations[i]}");
            }
            AnsiConsole.Write(table);

            return 0;
        }

    }
}