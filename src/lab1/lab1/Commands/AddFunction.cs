using Lab1.Functions;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;

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

        public override int Execute(CommandContext context, Settings settings)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<FunctionType>()
                    .Title("Select insert function")
                    .AddChoices(new[] {
                        FunctionType.Constant, FunctionType.Power,
                        FunctionType.Exponential, FunctionType.Logarithmic
                    }));

            Function function = choice switch
            {
                FunctionType.Constant => new Constant(AnsiConsole.Prompt(new TextPrompt<double>("Enter C for function f(x) = C :"))),
                FunctionType.Exponential => new ExponentialFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * A^x :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * A^x :"))
                    ),
                FunctionType.Logarithmic => new LogarithmicFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * log_A(x) :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * log_A(x) :"))
                    ),
                FunctionType.Power => new PowerFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter B for function f(x) = B * x^A :")),
                    AnsiConsole.Prompt(new TextPrompt<double>("Enter A for function f(x) = B * x^A :"))
                    )
            };

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
                        catch (ArgumentOutOfRangeException exp)
                        {
                            return ValidationResult.Error();
                        }
                    }));

            return 0;

        }
    }
}
