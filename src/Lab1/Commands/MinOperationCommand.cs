using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;
using Lab1.Model;

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
            var str_lhs = new TextPrompt<int>("[green]Введите левый операнд [/]");
            int lhs = AnsiConsole.Prompt(str_lhs);

            var str_rhs = new TextPrompt<int>("[green]Введите правый операнд [/]");
            int rhs = AnsiConsole.Prompt(str_rhs);

            AnsiConsole.MarkupLine($"[green]Минимальная операция для чисел {lhs} и {rhs}: {_operationsRepository.MinElement(lhs, rhs)}[/]");


            return 0;
        }

    }
}