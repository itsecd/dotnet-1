using PPLab1.Model;
using PPLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PPLab1.Commands
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
              .Title("Select function type: ")
              .AddChoices("Constant", "Power function", "Exponential function", "Logarithm"));

            Function newFunction = functionType switch
            {
                "Constant" => new Const(
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input coefficient: [/]"))
                    ),
                "Power function" => new PowerFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input power: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input coefficient: [/]"))
                    ),
                "Exponential function" => new ExpFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input exponent: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input coefficient: [/]"))
                    ),
                "Logarithm" => new LogFunct(
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input base: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[seagreen1]Input coefficient: [/]"))
                    ),
                _ => null
            };

            if (newFunction == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown function: {functionType}[/]");
                return -1;
            }
            _functionsRepository.AddFunction(newFunction);
            AnsiConsole.MarkupLine($"[skyblue1]Done![/]");
            return 0;
        } 
    }
}
