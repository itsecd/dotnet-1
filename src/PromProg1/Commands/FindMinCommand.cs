using PromProg1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    public class FindMinCommand : Command<FindMinCommand.FindMinSettings>
    {
        public class FindMinSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public FindMinCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FindMinSettings settings)
        {
            double operand1;
            while (true)
            {
                AnsiConsole.MarkupLine("Введите первый операнд");
                string strIndex = Console.ReadLine();
                if (double.TryParse(strIndex, out operand1))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный операнд не является числом\n");
                }
            }
            double operand2;
            while (true)
            {
                AnsiConsole.MarkupLine("Введите второй операнд");
                string strIndex = Console.ReadLine();
                if (double.TryParse(strIndex, out operand2))
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный операнд не является числом\n");
                }
            }

            var findMinResult = _operationsRepository.FindMin(operand1, operand2);
            if (findMinResult != null)
            {
                Console.WriteLine($"Для чисел {operand1} и {operand2} минимальной будет операция {findMinResult}");
                Console.WriteLine($"Для чисел {operand1} и {operand2} минимальная операция, найденная с помощью Linq: {_operationsRepository.FindMinLinq(operand1, operand2)}");
            }
            else
            {
                Console.WriteLine("Коллекция пуста");
            }
            return 0;
        }
    }
}