using lab1.services.interfaces;
using model;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1.Commands
{
    public class InsertFunctionCommand : Command<InsertFunctionCommand.InsertFunctionSettings>
    {
        public class InsertFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public InsertFunctionCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertFunctionSettings settings)
        {
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
              .Title("Select function type: ")
              .AddChoices("Constant", "Power function", "Exponential function", "Logarithm"));

            int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("insertion index: "));

            Function newFunction = functionType switch
            {
                "Constant" => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<int>("x: "))
                    ),
                "Power function" => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<int>("x: "))
                    ),
                "Exponential function" => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<int>("x: "))
                    ),
                "Logarithm" => new Log(
                    AnsiConsole.Prompt(new TextPrompt<int>("x: "))
                    ),
                _ => null
            };

            if (newFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown function: {functionType}");
                return -1;
            }
            _functionsRepository.Insert(inputIndex, newFunction);
            AnsiConsole.MarkupLine("[green1]Done!");
            return 0;
        }
    }
}
