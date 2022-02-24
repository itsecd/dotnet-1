using lab1.Repositories;
using System;
using System.ComponentModel;
using Spectre.Console.Cli;
using Spectre.Console;

namespace lab1.Commands
{
    class RemoveBinaryOperation : Command<RemoveBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("--all")]
            [DefaultValue(false)]
            public bool removeAll { get; init; }
        }

        private readonly IBinaryOperationsRepository _repository;
        public RemoveBinaryOperation(IBinaryOperationsRepository repository) 
            => _repository = repository ?? throw new ArgumentNullException(nameof(RemoveBinaryOperation));
        public override int Execute(CommandContext context, Settings settings)
        {
            if (settings.removeAll)
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
                        catch (ArgumentOutOfRangeException exp)
                        {
                            return ValidationResult.Error();
                        }
                    }));

            return 0;
        }
    }

    
}

