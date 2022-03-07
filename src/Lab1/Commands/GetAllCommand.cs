using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetAllCommand : Command<GetAllCommand.GetAllSettings>
    {

        public class GetAllSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public GetAllCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllSettings settings)
        {
            var operations = _operationsRepository.GetAll();

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