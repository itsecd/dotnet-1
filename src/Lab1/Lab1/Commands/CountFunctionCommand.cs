using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Lab1.Commands
{
    class CountFunctionCommand : Command<CountFunctionCommand.CountFunctionSettings>
    {
        public class CountFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public CountFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
        }

        private void OwnCount(ref IFunctionsRepository _functionRepository)
        {
            Console.Clear();
            Console.WriteLine("Введите число: ");
            double x;
            int index = 0;
            try
            {
                x = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Похоже, вы ввели не число");
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
                Console.ReadKey(true);
                return;
            }
            var max = _functionRepository[0].GetValue(x);
            for (int i = 0; i < _functionRepository.Count; ++i)
            {
                if (_functionRepository[i].GetValue(x) >= max)
                {
                    max = _functionRepository[i].GetValue(x);
                    index = i;
                }
            }
            Console.WriteLine($"При x = {x} наибольшее значение принимает фукнция");
            Console.WriteLine($"{_functionRepository[index]}");
            Console.WriteLine($"f({x}) = {_functionRepository[index].GetValue(x)}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
            Console.ReadKey(true);
        }

        private void LinqCount(ref IFunctionsRepository _functionRepository)
        {
            Console.Clear();
            Console.WriteLine("Введите число: ");
            double x;
            try
            {
                x = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Похоже, вы ввели не число");
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться..");
                Console.ReadKey(true);
                return;
            }

            var maxFunc = _functionRepository.GetMaxValueFunction(x);

            Console.WriteLine($"При x = {x} наибольшее значение принимает фукнция");
            Console.WriteLine($"{maxFunc}");
            Console.WriteLine($"f({x}) = {maxFunc.GetValue(x)}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться..");
            Console.ReadKey(true);
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CountFunctionSettings settings)
        {
            if (_functionRepository.Count == 0)
            {
                Console.WriteLine("Контейнер пуст, расчёт невозможен");
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться..");
                Console.ReadKey(true);
                //  return;
            }

            Console.WriteLine("Использовать для вычислений:");
            Console.WriteLine("1 - Свой алгоритм");
            Console.WriteLine("2 - Linq");

            ConsoleKeyInfo k = Console.ReadKey(true);

            switch (k.Key)
            {
                case ConsoleKey.D1:
                    OwnCount(ref _functionRepository);
                    break;
                case ConsoleKey.D2:
                    LinqCount(ref _functionRepository);
                    break;
                default:
                    return 0;
            }

            return 0;
        }

    }
}
