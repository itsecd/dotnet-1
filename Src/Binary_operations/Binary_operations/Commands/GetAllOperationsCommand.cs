using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Binary_operations.Commands
{
    public class GetAllOperationsCommand : Command<GetAllOperationsCommand.GetAllOperationsSettings>
    {
        public class GetAllOperationsSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public GetAllOperationsCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllOperationsSettings settings)
        {
            var operations = _operationsRepository.GetOperations();
            var table = new Table();
            table.AddColumn("[yellow]Операция[/]");
            table.Border(TableBorder.Ascii2);
            for (var i = 0; i < operations.Count; ++i)
            {
                if (i == 10)
                    break;
                table.AddRow($"[mediumpurple2_1]{operations[i]}[/]");
            }
            if (operations.Count > 10)
                table.AddRow("[red3_1]...[/]", "[red3_1]...[/]", "[red3_1]...[/]");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}

