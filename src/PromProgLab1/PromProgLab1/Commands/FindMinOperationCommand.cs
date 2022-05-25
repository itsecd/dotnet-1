using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PromProgLab1.Commands
{
    public class FindMinOperationCommand : Command<FindMinOperationCommand.FindMinOperationSettings>
    {
        public class FindMinOperationSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public FindMinOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FindMinOperationSettings settings)
        {
            var lhsIndexPrompt = new TextPrompt<int>("[green]Введите левый операнд: [/]");
            int lhsIndex = AnsiConsole.Prompt<int>(lhsIndexPrompt);

            var rhsIndexPrompt = new TextPrompt<int>("[green]Введите правый операнд: [/]");
            int rhsIndex = AnsiConsole.Prompt<int>(rhsIndexPrompt);

            MinElemNotLinq(lhsIndex, rhsIndex);
            MinElemLinq(lhsIndex, rhsIndex);

            return 0;
        }

        private int MinElemNotLinq(int lhsIndex, int rhsIndex)
        {
            var operations = _operationsRepository.GetOperations();

            var minOperation = operations.Count > 0
                ? operations[0]
                : throw new InvalidOperationException("Коллекция пуста");
            var minValue = minOperation.Calculate(lhsIndex, rhsIndex);

            foreach (var operation in operations.Skip(1))
            {
                if (operation.Calculate(lhsIndex, rhsIndex) < minValue)
                {
                    minOperation = operation;
                    minValue = operation.Calculate(lhsIndex, rhsIndex);
                }

            }

            AnsiConsole.MarkupLine($"[green]Минимальная операция для чисел {lhsIndex} и {rhsIndex}: {minOperation} = {minValue}[/]");

            return 0;
        }

        private int MinElemLinq(int lhsIndex, int rhsIndex)
        {
            int minValue = int.MaxValue;
            var operations = _operationsRepository.GetOperations();

            minValue = operations.Min(operation => operation.Calculate(lhsIndex, rhsIndex));
            var minOperation = operations.First(operation => (operation.Calculate(lhsIndex, rhsIndex) == minValue));

            AnsiConsole.MarkupLine($"[green](System.Linq)Минимальная операция для чисел {lhsIndex} и {rhsIndex}: {minOperation} = {minValue}[/]");

            return 0;
        }
    }
}
