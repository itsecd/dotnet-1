using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functions;
using System.Xml.Serialization;
using System.IO;

namespace MenuSpace
{
    static class Menu
    {
        public static void MainMenu()
        {
            var lst = new List<Function>(10);
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
                Console.WriteLine("7 - Сериализовать контейнер в XML-файл");
                Console.WriteLine("8 - Десериализовать контейнер из XML-файла");
                Console.WriteLine("Esc - Завершить программу");

                ConsoleKeyInfo k = Console.ReadKey(true);

                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        AddMenu(ref lst);
                        break;
                    case ConsoleKey.D2:
                        DeleteMenu(ref lst);
                        break;
                    case ConsoleKey.D3:
                        ClearMenu(ref lst);
                        //lst.Clear();
                        break;
                    case ConsoleKey.D4:
                        CompareMenu(ref lst);
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Список функций: \n");
                        /*foreach (Function a in lst)
                        {
                            Console.WriteLine($"- {a}");
                        }*/
                        for (var i = 0; i < lst.Count; ++i)
                        {
                            if (i >= 10)
                            {
                                Console.WriteLine("...");
                                break;
                            }
                            Console.WriteLine($"{i}) {lst[i]}");
                        }
                        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D6:
                        CountMenu(ref lst);
                        break;
                    case ConsoleKey.D7:
                        SerializeMenu(ref lst);
                        break;
                    case ConsoleKey.D8:
                        DeSerializeMenu(ref lst);
                        break;
                    case ConsoleKey.Escape:
                        isProgramCompleted = true;
                        break;
                }


            } while (!isProgramCompleted);


        }

        static void AddMenu(ref List<Function> lst)
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
                        lst.Add(new ConstFunc(arg));
                        Console.WriteLine($"Функция: {lst[lst.Count - 1]}");
                        //choice = true;
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("\nВведите степень: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        lst.Add(new PowerFunc(arg));
                        Console.WriteLine($"Функция: {lst[lst.Count - 1]}");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("\nВведите основание: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        lst.Add(new ExpoFunc(arg, 2));
                        Console.WriteLine($"Функция: {lst[lst.Count - 1]}");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("\nВведите основание: ");
                        arg = Convert.ToDouble(Console.ReadLine());
                        lst.Add(new LogFunc(arg));
                        Console.WriteLine($"Функция: {lst[lst.Count - 1]}");
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

        static void DeleteMenu(ref List<Function> lst)
        {
            Console.Clear();

            Console.WriteLine("Удалить элемент из контейнера по индексу");
            Console.WriteLine("Введите индекс удаляемого элемента (или не число, чтобы вернуться назад): ");

            Function tmp;
            string input = Console.ReadLine();
            try
            {
                int result = Convert.ToInt32(input);
                /*if (result < 0 || result >= lst.Count)
                    return;*/
                tmp = lst[result];
                lst.RemoveAt(result);
            }
            catch
            {
                return;
            }

            Console.WriteLine($"Удалён элемент {tmp}");
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        static void ClearMenu(ref List<Function> lst)
        {
            Console.Clear();

            Console.WriteLine("Вы уверены, что хотите полностью очистить контейнер?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");

            ConsoleKeyInfo k = Console.ReadKey(true);

            switch (k.Key)
            {
                case ConsoleKey.D1:
                    lst.Clear();
                    break;
                default:
                    return;
            }

            Console.WriteLine("Список полностью очищен");
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        static void CompareMenu(ref List<Function> lst)
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

                if (lst[first_index].Equals(lst[second_index]))
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} одинаковы");
                    Console.WriteLine($"({lst[first_index]}) == ({lst[second_index]})");
                }
                else
                {
                    Console.WriteLine($"Функции под индексами {first_index} и {second_index} разные");
                    Console.WriteLine($"({lst[first_index]}) != ({lst[second_index]})");
                }
            }
            catch
            {
                return;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);
        }

        static void SerializeMenu(ref List<Function> lst)
        {
            if (lst.Count == 0)
            {
                Console.WriteLine("\nСписок пуст!");
                return;
            }
            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (FileStream fs = new FileStream("Functions.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lst);
            }
            Console.WriteLine("\nСписок функций сериализован в файл!");
        }

        static void DeSerializeMenu(ref List<Function> lst)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (var fs = new FileStream("Functions.xml", FileMode.OpenOrCreate))
            {
                var tmp = formatter.Deserialize(fs) as List<Function>;
                if (tmp.Count != 0)
                    lst = tmp;
            }
            Console.WriteLine("\nСписок функций десериализован из файла!");
        }

        static void CountMenu(ref List<Function> lst)
        {
            if (lst.Count == 0)
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
            var max = lst[0].getValue(x);
            for (int i = 0; i < lst.Count; ++i)
            {
                if (lst[i].getValue(x) >= max)
                {
                    max = lst[i].getValue(x);
                    index = i;
                }
            }
            Console.WriteLine($"При x = {x} наибольшее значение принимает фукнция");
            Console.WriteLine($"{lst[index]}");
            Console.WriteLine($"f({x}) = {lst[index].getValue(x)}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться");
            Console.ReadKey(true);
        }
    }
}
