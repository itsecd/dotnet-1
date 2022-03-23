using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ClearCommand : Command<ClearCommand.ClearSettings>
    {

        public class ClearSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public ClearCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearSettings settings)
        {
            var check = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]You want to delete all matrices?: [/]")
                .AddChoices("Yes", "No"));

            switch (check)
            {
                case "Yes":
                    _matricesRepository.Clear();
                    break;
                case "No":
                default:
                    break;
            };
            return 0;
        }

    }
}