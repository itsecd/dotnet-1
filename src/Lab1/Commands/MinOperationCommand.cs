using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class MinOperationCommand : Command<MinOperationCommand.MinOperationSettings>
    {

        public class MinOperationSettings : CommandSettings
        {
        }

        private readonly IOperationsRepository _operationsRepository;

        public MinOperationCommand(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinOperationSettings settings)
        {
            var strLhs = new TextPrompt<int>("[green]Введите левый операнд [/]");
            int lhs = AnsiConsole.Prompt(strLhs);

            var strRhs = new TextPrompt<int>("[green]Введите правый операнд [/]");
            int rhs = AnsiConsole.Prompt(strRhs);

            AnsiConsole.MarkupLine($"[green]Минимальная операция для чисел {lhs} и {rhs}: {_operationsRepository.MinOperation(lhs, rhs)}[/]");
            AnsiConsole.MarkupLine($"[green](System.Linq)Минимальная операция для чисел {lhs} и {rhs}: {_operationsRepository.MinOperationLinq(lhs, rhs)}[/]");

            return 0;
        }

    }

}