using System;
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
            
            int index1;
            int index2;
            double operand1;
            double operand2;
            string strIndex;
            int compareResult;
            while (true)
            {
                AnsiConsole.MarkupLine("Введите индекс первой операции");
                strIndex = Console.ReadLine();
                if (int.TryParse(strIndex, out index1))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный индекс не является целым числом\n");
                }
            }
            
            while (true)
            {
                AnsiConsole.MarkupLine("Введите индекс второй операции");
                strIndex = Console.ReadLine();
                if (int.TryParse(strIndex, out index2))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный индекс не является целым числом\n");
                }
            }
            
            while (true)
            {
                AnsiConsole.MarkupLine("Введите первый операнд");
                strIndex = Console.ReadLine();
                if (double.TryParse(strIndex, out operand1))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный операнд не является числом\n");
                }
            }
            
            
            while (true)
            {
                AnsiConsole.MarkupLine("Введите второй операнд");
                strIndex = Console.ReadLine();
                if (double.TryParse(strIndex, out operand2))
                {
                    compareResult  = _operationsRepository.CompareTwoOperations(index1, index2, operand1, operand2);
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный операнд не является числом\n");
                }
            }
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
