using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class ComputeFunctionCommand : Command<ComputeFunctionCommand.ComputeFunctionSettings>
    {
        public class ComputeFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public ComputeFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComputeFunctionSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>(
                "[green]Enter the index of the function :[/]"));
            double arg = AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter an argument :[/]"));
            var functions = _functionsRepository.GetAll();
            AnsiConsole.Write("Function  " + functions[index] + "\nValue  " + functions[index].Compute(arg));
            return 0;
        }
    }
}
