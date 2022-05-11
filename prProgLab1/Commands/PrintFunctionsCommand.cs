using prProgLab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace prProgLab1.Commands
{
    public class PrintFunctionsCommand : Command<PrintFunctionsCommand.PrintFunctionsSettings>
    {
        public class PrintFunctionsSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public PrintFunctionsCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintFunctionsSettings settings)
        {
            var functions = _functionsRepository.GetAll();
            var table = new Table();
            table.AddColumns("Тип", "Функция");

            for (var i = 0; i < functions.Count; i++)
            {
                table.AddRow(functions[i].GetType().Name, functions[i].ToString());
                if (i == 9) break;
            }

            if (functions.Count > 10)
                table.AddRow("...", "...");

            AnsiConsole.Write(table);

            return 0;
        }
    }
}