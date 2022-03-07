using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;
using Lab1.Model;

namespace Lab1.Commands
{
    public class CompareCommand : Command<CompareCommand.CompareSettings>
    {

        public class CompareSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public CompareCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareSettings settings)
        {
            var operations = _operationsRepository.GetAll();

            var strLhs = new TextPrompt<int>("[LightGreen]Введите индекс первой операции [/]");
            int lhsIndex = AnsiConsole.Prompt(strLhs);

            var strRhs = new TextPrompt<int>("[LightGreen]Введите индекс второй операции [/]");
            int rhsIndex = AnsiConsole.Prompt(strRhs);

            if (operations[lhsIndex].Equals(operations[rhsIndex]))
            {
                AnsiConsole.MarkupLine($"[green]{operations[lhsIndex]} == {operations[rhsIndex]}[/]");
                return 0;
            }
            AnsiConsole.MarkupLine($"[green]{operations[lhsIndex]} != {operations[rhsIndex]}[/]");
            return 0;
        }

    }
}