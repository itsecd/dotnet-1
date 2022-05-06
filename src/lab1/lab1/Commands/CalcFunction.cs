using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class CalcFunction : Command<CalcFunction.Settings>
    {
        public class Settings : CommandSettings
        {
        }
        private readonly IFunctionRepository _repository;

        public CalcFunction(IFunctionRepository repository)
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

            var argument = AnsiConsole.Prompt(
               new TextPrompt<int>("Enter function argument")
                   .ValidationErrorMessage("[red]That's not a valid argument[/]")
                   );

            AnsiConsole.Write($"The result of the function is {functions[indexFunction].Calculation(argument)}");

            return 0;
        }
    }
}
