using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functions;
using System.Xml.Serialization;
using System.IO;
using Lab1.FunctionsRepository;

namespace Lab1.Menu
{
    static class Menu
    {
        //private readonly IFunctionsRepository functionRepository;
        public static void MainMenu(ref IFunctionsRepository functionRepository)
        {
            //var functionRepository = new List<Function>(10);
            bool isProgramCompleted = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Добавить функцию в контейнер");
                Console.WriteLine("2 - Удалить функцию из контейнера по индексу");
                Console.WriteLine("3 - Очистить контейнер");
                Console.WriteLine("4 - Сравнить два объекта по индексам");
                Console.WriteLine("5 - Вывести список на экран");
                Console.WriteLine("6 - Функция, принимающая наибольшее значение при заданном x");
                Console.WriteLine("Esc - Завершить программу");

                ConsoleKeyInfo k = Console.ReadKey(true);

                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        AddMenu(ref functionRepository);
                        break;
                    case ConsoleKey.D2:
                        DeleteMenu(ref functionRepository);
                        break;
                    case ConsoleKey.D3:
                        ClearMenu(ref functionRepository);
                        break;
                    case ConsoleKey.D4:
                        CompareMenu(ref functionRepository);
                        break;
                    case ConsoleKey.D5:
                        WriteMenu(ref functionRepository);
                        break;
                    case ConsoleKey.D6:
                        CountMenu(ref functionRepository);
                        break;
                    case ConsoleKey.Escape:
                        isProgramCompleted = true;
                        break;
                }


            } while (!isProgramCompleted);


        }

        public static void AddMenu(ref IFunctionsRepository functionRepository)
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

                //Function func;
                double arg;

                bool choice = false;
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nВведите коэффициент: ");
                        arg = Convert.ToDouble(Console.ReadLine());

                        functionRepository.Add(new ConstFunc(arg));

                        //Console.WriteLine($"Функция: {functionRepository[functionRepository.Count - 1]}");
                        //choice = true;
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("\nВведите степень: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        functionRepository.Add(new PowerFunc(arg));

                        //Console.WriteLine($"Функция: {functionRepository[functionRepository.Count - 1]}");

                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("\nВведите основание: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        functionRepository.Add(new ExpoFunc(arg, 2));

                        //Console.WriteLine($"Функция: {functionRepository[functionRepository.Count - 1]}");

                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("\nВведите основание: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        functionRepository.Add(new LogFunc(arg));

                        //Console.WriteLine($"Функция: {functionRepository[functionRepository.Count - 1]}");

                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.Escape:
                        choice = true;
                        break;
                }
                if (choice)
                    break;
            } while (true);
        }

        public static void DeleteMenu(ref IFunctionsRepository functionRepository)
        {
            Console.Clear();

            Console.WriteLine("Удалить элемент из контейнера по индексу");
            Console.WriteLine("Введите индекс удаляемого элемента (или не число, чтобы вернуться назад): ");

            Function tmp;
            string input = Console.ReadLine();
            try
            {
                int result = Convert.ToInt32(input);
                /*if (result < 0 || result >= functionRepository.Count)
                    return;*/
                tmp = functionRepository[result];
                functionRepository.Delete(result);
            }
            catch
            {
                return;
            }

            Console.WriteLine($"Удалён элемент {tmp}");
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        public static void ClearMenu(ref IFunctionsRepository functionRepository)
        {
            Console.Clear();

            Console.WriteLine("Вы уверены, что хотите полностью очистить контейнер?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");

            ConsoleKeyInfo k = Console.ReadKey(true);

            switch (k.Key)
            {
                case ConsoleKey.D1:
                    functionRepository.Clear();
                    break;
                default:
                    return;
            }

            Console.WriteLine("Список полностью очищен");
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        public static void CompareMenu(ref IFunctionsRepository functionRepository)
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

                if (functionRepository[first_index].Equals(functionRepository[second_index]))
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} одинаковы");
                    Console.WriteLine($"({functionRepository[first_index]}) == ({functionRepository[second_index]})");
                }
                else
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} разные");
                    Console.WriteLine($"({functionRepository[first_index]}) != ({functionRepository[second_index]})");
                }
            }
            catch
            {
                return;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        public static void CountMenu(ref IFunctionsRepository functionRepository)
        {
            if (functionRepository.Count == 0)
                return;
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
            var max = functionRepository[0].getValue(x);
            for (int i = 0; i < functionRepository.Count; ++i)
            {
                if (functionRepository[i].getValue(x) >= max)
                {
                    max = functionRepository[i].getValue(x);
                    index = i;
                }
            }
            Console.WriteLine($"При x = {x} наибольшее значение принимает фукнция");
            Console.WriteLine($"{functionRepository[index]}");
            Console.WriteLine($"f({x}) = {functionRepository[index].getValue(x)}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
            Console.ReadKey(true);
        }

        public static void CountMenuLinq(ref IFunctionsRepository functionRepository)
        {
            if (functionRepository.Count == 0)
                return;
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
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
                Console.ReadKey(true);
                return;
            }

            var maxFunc = functionRepository.GetMaxValueFunction(x);

            Console.WriteLine($"При x = {x} наибольшее значение принимает фукнция");
            Console.WriteLine($"{maxFunc}");
            Console.WriteLine($"f({x}) = {maxFunc.getValue(x)}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
            Console.ReadKey(true);
        }

        public static void WriteMenu(ref IFunctionsRepository functionRepository)
        {
            Console.Clear();
            Console.WriteLine("Список функций: \n");
            Console.WriteLine(functionRepository);
            /*for (var i = 0; i < functionRepository.Count; ++i)
            {
                if (i >= 10)
                {
                    Console.WriteLine("...");
                    break;
                }
                Console.WriteLine($"{i}) {functionRepository[i]}");
            }*/
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }
    }
}
