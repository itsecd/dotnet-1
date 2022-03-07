using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
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
            double value = AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a value to calculate the functions:[/]"));
            
            var functions = _functionsRepository.GetFunctions();

            if (functions.Count == 0)
            {
                AnsiConsole.MarkupLine("[blue]No functions for calculations.[/]");
                return 0;
            }
            
            Function maxFunction = null;

            var maxValue = functions.Max(function => function.Calculate(value));
            foreach (var function in functions)
            {
                if (function.Calculate(value) == maxValue)
                {
                    maxFunction = function;
                }
            }
            Console.WriteLine(maxFunction);
            return 0;
        }
    }
}
