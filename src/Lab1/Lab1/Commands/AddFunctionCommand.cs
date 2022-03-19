using System;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using Lab1.FunctionsRepository;
using Lab1.Model;

namespace Lab1.Commands
{
    class AddFunctionCommand : Command<AddFunctionCommand.AddFunctionSettings>
    {
        public class AddFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public AddFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFunctionSettings settings)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Добавить функцию в контейнер:");
                Console.WriteLine("1 - Константная функция");
                Console.WriteLine("2 - Степенная функция вида x^a");
                Console.WriteLine("3 - Экспоненциальная функция вида a^x");
                Console.WriteLine("4 - Логарифмическая функция вида log(a)_X");
                Console.WriteLine("Esc - Выход");

                ConsoleKeyInfo k = Console.ReadKey(true);

                double arg;

                bool ifEscape = false;
                bool ifNoError = true;
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nВведите коэффициент: ");
                        ifNoError = double.TryParse(Console.ReadLine(), out arg);
                        if (ifNoError)
                            _functionRepository.Add(new ConstFunc(arg));
                        else
                            Console.WriteLine("Ошибка! Новая функция не была добавлена.");
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("\nВведите степень: ");
                        ifNoError = double.TryParse(Console.ReadLine(), out arg);
                        if (ifNoError)
                            _functionRepository.Add(new PowerFunc(arg));
                        else
                            Console.WriteLine("Ошибка! Новая функция не была добавлена.");
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("\nВведите основание: ");
                        ifNoError = double.TryParse(Console.ReadLine(), out arg);
                        if (ifNoError)
                            _functionRepository.Add(new ExpoFunc(arg, 2));
                        else
                            Console.WriteLine("Ошибка! Новая функция не была добавлена.");
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("\nВведите основание: ");
                        ifNoError = double.TryParse(Console.ReadLine(), out arg);
                        if (ifNoError)
                            _functionRepository.Add(new LogFunc(arg));
                        else
                            Console.WriteLine("Ошибка! Новая функция не была добавлена.");
                        break;

                    case ConsoleKey.Escape:
                        ifEscape = true;
                        break;
                }
                if (ifEscape)
                    break;
                if (ifNoError)
                    Console.WriteLine($"Функция: {_functionRepository[_functionRepository.Count - 1]}");
                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить..");
                Console.ReadKey(true);
            } while (true);

            return 0;
        }

    }
}
