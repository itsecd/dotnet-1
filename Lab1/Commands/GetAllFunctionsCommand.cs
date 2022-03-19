using Lab1.Model;
using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetAllFunctionsCommand : Command<GetAllFunctionsCommand.GetAllFunctionsSettings>
    {
        public class GetAllFunctionsSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetAllFunctionsCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetAll();
            var table = new Table();
            table.AddColumns("Function", "Data", "Derivative");
            int count = 0;
            foreach (Function f in functions)
            {
                if (count < 10)
                    table.AddRow(f.GetType().Name, f.ToString(), f.GetDerivative().ToString());
                else
                {
                    table.AddRow("...", "...", "...");
                    break;
                }
                count++;
            }
            AnsiConsole.Write(table);

            return 0;
        }
    }
}
