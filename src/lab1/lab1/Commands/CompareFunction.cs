using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;

namespace lab1.Commands
{
    class CompareFunction : Command<CompareFunction.Settings>
    {
        public class Settings : CommandSettings
        {
        }
        private readonly IFunctionRepository _repository;

        public CompareFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var functions = _repository.GetAll();

            var indexFirst = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index of first element")
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

            var indexSecond = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index of second element")
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

            AnsiConsole.Write($"Comparision result:: {functions[indexFirst].Equals(functions[indexSecond])}");

            return 0;
        }
    }
}
