using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
{
    public class MinOperation : Command<MinOperation.MinOperationSettings>
    {
        public class MinOperationSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public MinOperation(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinOperationSettings settings)
        {
            var strLhs = new TextPrompt<int>("[green]Введите левое число: [/]");
            int left = AnsiConsole.Prompt<int>(strLhs);

            var strRhs = new TextPrompt<int>("[green]Введите правое число: [/]");
            int right = AnsiConsole.Prompt<int>(strRhs);

            MinElem(left, right);
            return 0;
        }

        private int MinElem(int lhs, int rhs)
        {
            int minValue = int.MaxValue;
            Operation minOperation = new Substraction();

            foreach (var operation in _operationsRepository.GetOperations())
            {
                if (operation.Calculate(lhs, rhs) < minValue)
                {
                    minOperation = operation;
                    minValue = operation.Calculate(lhs, rhs);
                }

            }

            AnsiConsole.MarkupLine($"[green]Минимальная операция для чисел {lhs} и {rhs}: {minOperation} = {minValue}[/]");

            return 0;
        }
    }
}
