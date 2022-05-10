using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
{
    public class GetAllOperationsCommand : Command<GetAllOperationsCommand.GetAllOperationsSettings>
    {
        public class GetAllOperationsSettings : CommandSettings
        { }

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
                {
                    table.AddRow("[red3_1]...[/]", "[red3_1]...[/]", "[red3_1]...[/]");
                    break;
                }
                table.AddRow($"[mediumpurple2_1]{operations[i]}[/]");
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}