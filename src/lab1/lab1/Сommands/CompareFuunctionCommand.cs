using System;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using lab1.services.interfaces;

namespace Lab1.Commands
{
    public class CompareFunctionCommand : Command<CompareFunctionCommand.CompareFunctionSettings>
    {
        public class CompareFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public CompareFunctionCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFunctionSettings settings)
        {
            int inputIndex1 = AnsiConsole.Prompt(new TextPrompt<int>("1: "));
            int inputIndex2 = AnsiConsole.Prompt(new TextPrompt<int>("2: "));

            if (inputIndex1 < 0 || inputIndex2 < 0)
            {
                AnsiConsole.MarkupLine("out of range");
                return -1;
            }

            var resCompare = _functionsRepository.CompareFunction(inputIndex1, inputIndex2) ? "[green1]The functions are equal" : "[red]The functions arn't equal[/]";
            AnsiConsole.MarkupLine(resCompare);
            AnsiConsole.MarkupLine("[green1]Done!");
            return 0;
        }
    }
}
