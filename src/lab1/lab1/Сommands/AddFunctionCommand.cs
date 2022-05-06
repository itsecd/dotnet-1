using lab1.services.interfaces;
using model;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Сommands
{
    public class AddFunctionCommand : Command<AddFunctionCommand.AddFunctionSettings>
    {
        public class AddFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public AddFunctionCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFunctionSettings settings)
        {
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
              .Title("Select function type: ")
              .AddChoices("Constant", "Power function", "Exponential function", "Logarithmic function"));

            Function newFunction = functionType switch
            {
                "Constant" => new Constant(AnsiConsole.Prompt(new TextPrompt<double>("x: "))),
                "Power function" => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("x:"))
                    ),
                "Exponential function" => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("x:"))
                    ),
                "Logarithmic function" => new Log(
                    AnsiConsole.Prompt(new TextPrompt<double>("x:"))
                    )
            };

            if (newFunction == null)
            {
                AnsiConsole.MarkupLine($"Unknown function: {functionType}");
                return -1;
            }
            _functionsRepository.AddFunction(newFunction);
            AnsiConsole.MarkupLine("done");
            return 0;
        }
    }
}
