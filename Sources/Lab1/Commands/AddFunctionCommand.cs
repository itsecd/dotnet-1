using Lab1.Models;
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
            var choice = new List<string>()
                { "Constant", "Linear function", "Quadratic function", "Sine wave function", "Cosine wave function" };

            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select function type: ")
                .AddChoices(choice));

            switch (functionType.ToString())
            {
                case "Constant":
                    {
                        var function = new ConstantFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Constant: [/]")));
                        _functionsRepository.InsertFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Index to insert element: [/]")), function);
                        break;
                    }
                case "Linear function":
                    {
                        var function = new LinearFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at  х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Constant: [/]"))
                            );
                        _functionsRepository.InsertFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Index to insert element: [/]")), function);
                        break;
                    }
                case "Quadratic function":
                    {
                        var function = new QuadraticFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at x^2: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Constant: [/]"))
                            );
                        _functionsRepository.InsertFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Index to insert element: [/]")), function);
                        break;
                    }
                case "Sine wave function":
                    {
                        var function = new SineFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at sin: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Constant (phase): [/]"))
                            );
                        _functionsRepository.InsertFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Index to insert element: [/]")), function);
                        break;
                    }
                case "Cosine wave function":
                    {
                        var function = new CosineFunction(
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at cos: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Coefficient at х: [/]")),
                            AnsiConsole.Prompt(new TextPrompt<double>("[blue]Constant (phase): [/]"))
                            );
                        _functionsRepository.InsertFunction(
                            AnsiConsole.Prompt(new TextPrompt<int>("[blue]Index to insert element: [/]")), function);
                        break;
                    }
            }
            return 0;
        }
    }
}
