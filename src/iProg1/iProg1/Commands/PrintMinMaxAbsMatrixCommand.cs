using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//PrintMinMaxAbsMatrix
namespace iProg1.Commands
{
    public class PrintMinMaxAbsMatrixCommand : Command<PrintMinMaxAbsMatrixCommand.PrintMinMaxAbsMatrixSettings>
    {
        public class PrintMinMaxAbsMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matrixRepository;
        
        public PrintMinMaxAbsMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintMinMaxAbsMatrixSettings settings)
        {
            var rule = new Rule("[green]Without Linq[/]").RuleStyle("red dim");
            AnsiConsole.Write(rule);
            _matrixRepository.PrintMinMaxAbsMatrix();
            AnsiConsole.Write(rule);
            rule = new Rule("[red]With Linq[/]").RuleStyle("green dim");
            AnsiConsole.Write(rule);
            _matrixRepository.PrintMinMaxAbsMatrixWithLinq();
            AnsiConsole.Write(rule);
            return 1;
        }
    }
}
