using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class AddFunctionCommand : Command<AddFunctionCommand.AddFunctionSettings>
    {
        public class AddFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public AddFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFunctionSettings settings)
        {
            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a function type:")
                .AddChoices("Constant function", "Power function", "Exponential function", "Logarithm function"));

            Function selectedFunction = functionType switch
            {
                "Constant function" => new ConstantFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a coefficient:[/]"))
                    ),
                "Power function" => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a coefficient:[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter degree:[/]"))
                    ),
                "Exponential function" => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a base:[/]"))
                    ),
                "Logarithm function" => new LogarithmFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Enter a base:[/]"))
                    ),
                _ => null
            };

            if (selectedFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown function: {functionType}[/]");
                return -1;
            }
            _functionsRepository.AddFunction(selectedFunction);

            return 0;
        }
    }
}
