using ConsoleApp1.Model;
using ConsoleApp1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp1.Commands
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
            Func? function = null;
            foreach (Func elem in functions)
            {
                if (elem.GetDerivative().Compute(arg) < min)
                    min = elem.GetDerivative().Compute(arg);
            }
            foreach (Func elem in functions)
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