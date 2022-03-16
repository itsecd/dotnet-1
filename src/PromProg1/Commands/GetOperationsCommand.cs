using System;
using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using PromProg1.Models;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class GetOperationsCommand : Command<ClearRepositoryCommand.ClearRepositorySettings>
    {
        public class GetOperationsSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public GetOperationsCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearRepositoryCommand.ClearRepositorySettings settings)
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
                table.AddRow("...[/]", "...[/]", "...[/]");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
