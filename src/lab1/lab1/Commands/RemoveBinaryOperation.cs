using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.ComponentModel;

namespace Lab1.Commands
{
    class RemoveBinaryOperation : Command<RemoveBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("--all")]
            [DefaultValue(false)]
            public bool RemoveAll { get; init; }
        }

        private readonly IBinaryOperationsRepository _repository;
        public RemoveBinaryOperation(IBinaryOperationsRepository repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public override int Execute(CommandContext context, Settings settings)
        {
            if (settings.RemoveAll)
            {
                _repository.RemoveAll();
                return 0;
            }

            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter index of removing element")
                    .ValidationErrorMessage("[red]That's not a valid index[/]")
                    .Validate(index =>
                    {
                        try
                        {
                            _repository.RemoveOperation(index);

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

