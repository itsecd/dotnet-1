using Lab1.Functions;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class AddFunction : Command<AddFunction.Settings>
    {
        public class Settings : CommandSettings
        {
        }

        private readonly IFunctionRepository _repository;

        public AddFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute([NotNull]CommandContext context, [NotNull]Settings settings)
        {
            var functionFactory = new Dictionary<string, Func<Function>>
            {
                {
                    "Constant",() => new Constant(
                            AnsiConsole.Prompt(new TextPrompt<double>("Enter C for function f(x) = C :"))
                        )
                },
                {
                    "Exponential",() => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * A^x :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * A^x :"))
                    )
                },
                {
                    "Logarithmic",() => new LogarithmicFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * log_A(x) :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * log_A(x) :"))
                    )
                },
                {
                    "Power",() => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * x^A :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * x^A :"))
                    )
                }
            };

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select insert function")
                    .AddChoices(functionFactory.Keys));

            var function = functionFactory[choice].Invoke();

            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter insert index")
                    .ValidationErrorMessage("[red]That's not a valid index[/]")
                    .Validate(index =>
                    {
                        try
                        {
                            _repository.AddFunction(index, function);

                            return ValidationResult.Success();
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return ValidationResult.Error();
                        }
                    }));

            return 0;

        }
    }
}
