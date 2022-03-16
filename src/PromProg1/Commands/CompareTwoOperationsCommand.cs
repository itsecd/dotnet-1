using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class CompareTwoOperationsCommand : Command<CompareTwoOperationsCommand.CompareTwoOperationsSettings>
    {
        public class CompareTwoOperationsSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public CompareTwoOperationsCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareTwoOperationsSettings settings)
        {
            int compareResult;
            int index1 = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс первой операции"));
            int index2 = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс второй операции"));
            double operand1 = AnsiConsole.Prompt(new TextPrompt<int>("Введите первый операнд"));
            double operand2 = AnsiConsole.Prompt(new TextPrompt<int>("Введите второй операнд"));
            compareResult  = _operationsRepository.CompareTwoOperations(index1, index2, operand1, operand2);
            if (compareResult == -1)
            {
                AnsiConsole.MarkupLine("При заданных операндах результат первой операции меньше результата второй операции");
            }
            else if (compareResult == 1)
            {
                AnsiConsole.MarkupLine("При заданных операндах результат первой операции больше результата второй операции");
            }
            else if (compareResult == 0)
            {
                AnsiConsole.MarkupLine("При заданных операндах результат первой операции равен результату второй операции");
            }
            return 0;
        }
    }
}
