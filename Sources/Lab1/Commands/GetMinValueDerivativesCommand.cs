using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    internal class GetMinValueDerivativesCommand : Command<GetMinValueDerivativesCommand.GetMinValueDerivativesSettings>
    {
        public class GetMinValueDerivativesSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetMinValueDerivativesCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] GetMinValueDerivativesSettings settings)
        {

            double value = AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter value :[/]"));
            var functions = _functionsRepository.GetFunctions();

            var minValue = functions.Min(x => x.GetDerivative().Calculate(value));
            var FirstMinValue = functions.First(x => x.GetDerivative().Calculate(value) == minValue);

            double min = double.MaxValue;
            Function result = functions[0];
            foreach (Function function in functions)
            {
                if (function.GetDerivative().Calculate(value) < min)
                {
                    min = function.GetDerivative().Calculate(value);
                    result = function;
                }
            }

            var table = new Table();
            table.AddColumn(new TableColumn("Method"));
            table.AddColumn(new TableColumn("Result"));
            table.AddColumn(new TableColumn("Function value"));
            table.AddRow($"System.Linq", FirstMinValue.ToString(), Math.Round(FirstMinValue.Calculate(value), 3).ToString());
            table.AddRow($"Code", result.ToString(), Math.Round(result.Calculate(value)).ToString());

            AnsiConsole.Write(table);
            return 0;
        }
    }
}
