using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class CompareCommand : Command<CompareCommand.CompareSettings>
    {

        public class CompareSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public CompareCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareSettings settings)
        {
            int lhsIndex = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]First matrix index: [/]"));
            int rhsIndex = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]Second matrix index: [/]"));

            var lhs = _matricesRepository.GetMatrix(lhsIndex);
            var rhs = _matricesRepository.GetMatrix(rhsIndex);
            var res = lhs.Equals(rhs);

            AnsiConsole.MarkupLine($"[blue]Comparision result: {res}[/]");
            return 0;
        }

    }
}