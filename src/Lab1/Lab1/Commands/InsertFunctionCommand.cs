using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
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
               .Title("Select a function type:")
               .AddChoices("Constant function", "Power function", "Exponential function", "Logarithm function"));

            int index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter an index to insert into the collection:[/]"));

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

            try
            {
                _functionsRepository.InsertFunction(index, selectedFunction);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
}
