using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class MaxFunctionCommand : Command<MaxFunctionCommand.MaxFunctionSettings>
    {
        public class MaxFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public MaxFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MaxFunctionSettings settings)
        {
            int value = AnsiConsole.Prompt(new TextPrompt<int>(
                "[aqua]Input the value for which you want to find the maximum function: [/]"));

            var functions = _functionsRepository.GetFunction();

            if (functions == null)
            {
                AnsiConsole.MarkupLine("[red]The list is empty[/]");
                return 0;
            }

            var maxResult = functions.Max(f => f.Calculation(value) ?? int.MinValue);

            var res = (from func in functions
                       where func.Calculation(value) == maxResult
                       select func).FirstOrDefault();

            AnsiConsole.MarkupLine($"[green1]Max function is {res}[/]");

            return 0;
        }
    }
}
