using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ViewTableCommand : Command<ViewTableCommand.ViewTableSettings>
    {
        public class ViewTableSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public ViewTableCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ViewTableSettings settings)
        {
            var functions = _functionsRepository.GetFunction();

            var table = new Table();
            int counter = 0;

            table.AddColumn("Type");
            table.AddColumn("Function");
            table.AddColumn("Derivative");

            if (functions != null)
            {
                foreach (Function function in functions)
                {
                    if (counter < 10)
                    {
                        table.AddRow(function.GetType().Name, function.ToString(), function.Derivative().ToString());
                        ++counter;
                    }
                    else
                    {
                        table.AddRow("...", "...", "...");
                        break;
                    }
                }
            }
            else
                table.AddRow("null", "null", "null");
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
