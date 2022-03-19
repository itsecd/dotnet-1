using Lab1.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class GetDerivativeFunctionCommand : Command<GetDerivativeFunctionCommand.GetDerivativeFunctionSettings>
    {
        public class GetDerivativeFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetDerivativeFunctionCommand(IFunctionsRepository functionRepository)
        {
            _functionsRepository = functionRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetDerivativeFunctionSettings settings)
        {
            int index = AnsiConsole.Prompt(new TextPrompt<int>(
                "[green]Enter the index of the function for which to calculate the derivative :[/]"));
            var functions = _functionsRepository.GetAll();
            var derivative = functions[index].GetDerivative();
            AnsiConsole.Write("Function  " + functions[index] + "\nDerivative  " + derivative);
            return 0;
        }
    }
}
