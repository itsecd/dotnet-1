using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class MinCommand : Command<MinCommand.MinSettings>
    {

        public class MinSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public MinCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinSettings settings)
        {
            var strLhs = new TextPrompt<int>("[LightGreen]Введите левый операнд [/]");
            int lhs = AnsiConsole.Prompt(strLhs);

            var strRhs = new TextPrompt<int>("[LightGreen]Введите правый операнд [/]");
            int rhs = AnsiConsole.Prompt(strRhs);

            MinNotLinq(lhs, rhs);
            MinLinq(lhs, rhs);

            return 0;
        }

        private int MinNotLinq(int lhs, int rhs)
        {
            int minValue = int.MaxValue;
            Operation minOperation = new Sub();

            foreach (var operation in _operationsRepository.GetAll())
            {
                if (operation.Compute(lhs, rhs) < minValue)
                {
                    minOperation = operation;
                    minValue = operation.Compute(lhs, rhs);
                }

            }

            AnsiConsole.MarkupLine($"[green]Минимальная операция для чисел {lhs} и {rhs}: {minOperation} = {minValue}[/]");

            return 0;
        }

        private int MinLinq(int lhs, int rhs)
        {
            int minValue = int.MaxValue;
            var operations = _operationsRepository.GetAll();

            minValue = operations.Min(operation => operation.Compute(lhs, rhs));
            var minOperation = operations.First(operation => (operation.Compute(lhs, rhs) == minValue));

            AnsiConsole.MarkupLine($"[green](System.Linq)Минимальная операция для чисел {lhs} и {rhs}: {minOperation} = {minValue}[/]");

            return 0;
        }
    }

}