using Lab1.Operations;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;

namespace Lab1.Commands
{
    class AddBinaryOperation : Command<AddBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
        }

        private readonly IBinaryOperationsRepository _repository;
        public AddBinaryOperation(IBinaryOperationsRepository repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public override int Execute(CommandContext context, Settings settings)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choice which binary operation to add?")
                    .AddChoices(new[] {
                        "Addition", "Multiplication",
                        "Subtraction", "Integer division",
                        "Operation get of remainder of division"
                    }));

            BinaryOperation binaryOp = choice switch
            {
                "Addition" => new Sum(),
                "Multiplication" => new Mul(),
                "Subtraction" => new Sub(),
                "Integer division" => new Div(),
                "Operation get of remainder of division" => new Rem(),
                _ => throw new NotImplementedException()
            };

            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter insert index")
                    .ValidationErrorMessage("[red]That's not a valid index[/]")
                    .Validate(index =>
                    {
                        try
                        {
                            _repository.AddOperation(index, binaryOp);

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

