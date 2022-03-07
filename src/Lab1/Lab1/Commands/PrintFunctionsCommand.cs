using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class PrintFunctionsCommand : Command<PrintFunctionsCommand.PrintFunctionsSettings>
    {
        public class PrintFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public PrintFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetFunctions();

            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Function");
            table.AddColumn("Derivative");
            int counter = 0;

            foreach (Function function in functions)
            {
                if (counter < 10)
                {
                    table.AddRow(function.GetType().Name, function.ToString(), function.Derivative().ToString());
                    ++counter;
                    continue;
                }
                table.AddRow("...", "...", "...");
                break;
            }

            AnsiConsole.Write(table);
            return 0;
        }
    }
}
