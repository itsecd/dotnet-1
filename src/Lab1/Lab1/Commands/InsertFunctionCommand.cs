using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class InsertFunctionCommand : Command<InsertFunctionCommand.InsertFunctionSettings>
    {
        public class InsertFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public InsertFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertFunctionSettings settings)
        {
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
              .Title("Select function type: ")
              .AddChoices("Constant", "Power function", "Exponential function", "Logarithm"));

            int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input the insertion index: [/]"));

            Function newFunction = functionType switch
            {
                "Constant" => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input coefficient: [/]"))
                    ),
                "Power function" => new Power(
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input power: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input coefficient: [/]"))
                    ),
                "Exponential function" => new Exponential(
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input exponent: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input coefficient: [/]"))
                    ),
                "Logarithm" => new Logarithm(
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input base: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input coefficient: [/]"))
                    ),
                _ => null
            };

            if (newFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown function: {functionType}[/]");
                return -1;
            }
            _functionsRepository.InsertFunction(newFunction, inputIndex);
            AnsiConsole.MarkupLine("[green1]Done![/]");
            return 0;
        }
    }
}
