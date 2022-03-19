using Spectre.Console.Cli;
using Lab1.Services;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Lab1.Model;

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
            foreach (Function f in functions)
            {
                table.AddRow(f.GetType().Name, f.ToString(), f.GetDerivative().ToString());
            }
            AnsiConsole.Write(table);
            return 0;
        }
    } 
}
