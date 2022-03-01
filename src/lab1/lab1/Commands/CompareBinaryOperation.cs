using Lab1.Repositories;
using System;
using System.ComponentModel;
using Spectre.Console.Cli;
using Spectre.Console;

namespace Lab1.Commands
{
    class CompareBinaryOperation : Command<CompareBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
        }

        private readonly IBinaryOperationsRepository _repository;
        public CompareBinaryOperation(IBinaryOperationsRepository repository) 
            => _repository = repository ?? throw new ArgumentNullException(nameof(CompareBinaryOperation));
        public override int Execute(CommandContext context, Settings settings)
        {
            var operations = _repository.GetAll();

            // Как лучше тут сделать ? 2 раза приходится ходить по списку (долго) для каждого эл.
            var indexFirst = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index of first element")
                    .ValidationErrorMessage("[red]That's not a valid index[/]")
                    .Validate(index =>
                    {
                        try
                        {
                            var _ = operations[index]; 
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
                            var _ = operations[index];

                            return ValidationResult.Success();
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return ValidationResult.Error();
                        }
                    }));

            AnsiConsole.Write($"Result of compare: {operations[indexFirst].Equals(operations[indexSecond])}" );

            return 0;
        }
    }

    
}

