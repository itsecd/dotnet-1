using lab1.Model;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
            int lhs = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]First matrix index: [/]"));
            int rhs = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]Second matrix index: [/]"));

            var res = _matricesRepository.Compare(lhs, rhs);

            AnsiConsole.MarkupLine($"[blue]Comparision result: {res}[/]");
            return 0;
        }

    }
}