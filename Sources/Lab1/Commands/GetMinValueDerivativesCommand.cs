using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            double arg = AnsiConsole.Prompt(new TextPrompt<double>("[blue]Введите значение :[/]"));
            var functions = _functionsRepository.GetFunctions();

            var minValue = functions.Min(x => x.GetDerivative().Calculate(arg));
            var FirstMinValue = functions.First(x => x.GetDerivative().Calculate(arg) == minValue);

            double min = double.MaxValue;
            Function? result = null;
            foreach (Function function in functions)
            {
                if (function.GetDerivative().Calculate(arg) < min)
                {
                    min = function.GetDerivative().Calculate(arg);
                    result = function;
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            AnsiConsole.WriteLine("Результат System.Linq функции: \t\t" + FirstMinValue);
            AnsiConsole.WriteLine("Результат вычисления с помощью кода: \t" + result);
            Console.ForegroundColor = ConsoleColor.White;
            return 0;
        }
    }
}
