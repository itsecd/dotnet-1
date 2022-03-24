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
            AnsiConsole.Write("Method with System.Linq return Function " + _functionsRepository.MinFunctionWithLINQ(arg)
               + "\nCustom Code return Function " + _functionsRepository.MinFunction(arg));
            return 0;


        }
    }
}