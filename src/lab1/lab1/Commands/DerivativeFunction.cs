using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class DerivativeFunction : Command<DerivativeFunction.Settings>
    {
        public class Settings : CommandSettings
        {
        }
        private readonly IFunctionRepository _repository;

        public DerivativeFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            var functions = _repository.GetAll();

            var indexFunction = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index of element which will be calculated")
                    .ValidationErrorMessage("[red]That's not a valid index[/]")
                    .Validate(index =>
                    {
                        try
                        {
                            var _ = functions[index];
                            return ValidationResult.Success();
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return ValidationResult.Error();
                        }
                    }));

            AnsiConsole.Write($"The derivative of the function {functions[indexFunction]} is {functions[indexFunction].Derivative()}");

            return 0;
        }
    }
}
