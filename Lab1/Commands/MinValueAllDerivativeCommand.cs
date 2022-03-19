using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console.Cli;
using Lab1.Services;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Lab1.Model;

namespace Lab1.Commands
{
    class MinValueAllDerivativeCommand : Command<MinValueAllDerivativeCommand.MinValueAllDerivativeSettings>
    {
        public class MinValueAllDerivativeSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public MinValueAllDerivativeCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinValueAllDerivativeSettings settings)
        {
            double arg = AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter an argument :[/]"));
            var functions = _functionsRepository.GetAll();

            var minValue = functions.Min(x => x.GetDerivative().Compute(arg));
            var funcMinValue = functions.First(x => x.GetDerivative().Compute(arg) == minValue);

            double min = double.MaxValue;
            Function? function = null;
            foreach (Function elem in functions)
            {
                if (elem.GetDerivative().Compute(arg) < min)
                    min = elem.GetDerivative().Compute(arg);
            }
            foreach (Function elem in functions)
            {
                if (elem.GetDerivative().Compute(arg) == min)
                    function = elem;
            }

            AnsiConsole.Write("Method with System.Linq return Function " + funcMinValue
                + "\nCustom Code return Function " + function);
            return 0;
            
        }
    }
}
