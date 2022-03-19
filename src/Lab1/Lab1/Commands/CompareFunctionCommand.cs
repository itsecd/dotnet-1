using System;
using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    class CompareFunctionCommand : Command<CompareFunctionCommand.CompareFunctionSettings>
    {
        public class CompareFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public CompareFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFunctionSettings settings)
        {
            Console.Clear();

            Console.WriteLine("Сравнение двух элементов между собой");
            Console.WriteLine("Введите индекс первого элемента: ");
            string input = Console.ReadLine();
            try
            {
                int first_index = Convert.ToInt32(input);

                Console.WriteLine("Введите индекс второго элемента: ");
                input = Console.ReadLine();
                var second_index = Convert.ToInt32(input);

                if (_functionRepository[first_index].Equals(_functionRepository[second_index]))
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} одинаковы");
                    Console.WriteLine($"({_functionRepository[first_index]}) == ({_functionRepository[second_index]})");
                }
                else
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} разные");
                    Console.WriteLine($"({_functionRepository[first_index]}) != ({_functionRepository[second_index]})");
                }
            }
            catch
            {
                Console.WriteLine("\nОшибка!");
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);

            return 0;
        }

    }
}
