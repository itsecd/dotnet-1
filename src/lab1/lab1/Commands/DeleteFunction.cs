using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class DeleteFunction : Command<DeleteFunction.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("--all")]
            [DefaultValue(false)]
            public bool RemoveAll { get; init; }
        }
        private readonly IFunctionRepository _repository;

        public DeleteFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
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
                            _repository.RemoveFunction(index);

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
