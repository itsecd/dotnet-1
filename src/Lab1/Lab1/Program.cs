using System;
using System.IO;
using Functions;
using System.Collections.Generic;
//using System.Xml;
using System.Xml.Serialization;
// using Math;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Ваше имя: {name}");*/

            MainMenu();
            /*List<Function> lst = new List<Function>();
            Function cfunc = new ConstFunc(10);
            Function pfunc = new PowerFunc(10);
            lst.Add(cfunc);
            lst.Add(pfunc);
            
            foreach(Function a in lst)
            {
                Console.WriteLine(a);
            }*/

        }

        static void MainMenu()
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
            for(int i = 0; i < lst.Count; ++i)
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

    

    /*abstract class FunctionClass
    {
        // const double coef = 1;

        // const double a = 0;

        public abstract double getValue(double x);

        public abstract FunctionClass getDerivative();
    }

    class ConstFunc : FunctionClass
    {
        double a;

        double coef;

        public override double getValue(double x = 0)
        {
            return coef * a;
        }

        public override FunctionClass getDerivative()
        {
            return new ConstFunc(0);
        }

        ConstFunc(double _coef)
        {
            coef = _coef;
        }
    }

    class PowerFunc : FunctionClass // x^a
    {
        double a;

        double coef;

        public override double getValue(double x = 0)
        {
            if (x == 0 && a < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return coef * Math.Pow(x, a); // 0 нельзя возводить в отрицательные степени!
        }

        public override FunctionClass getDerivative()
        {
            return new PowerFunc(a - 1, a * coef);
        }

        PowerFunc(double value, double _coef = 1)
        {
            a = value;
            coef = _coef;
        }
    }

    class ExpoFunc : FunctionClass // a^x, не готово
    {
        double a;

        double coef;

        public override double getValue(double x = 0)
        {
            if (a == 0 && x < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return coef * Math.Pow(a, x); // 0 нельзя возводить в отрицательные степени!
        }

        public override FunctionClass getDerivative()
        {
            return new ExpoFunc(a, Math.Log(a, Math.E));
        }

        ExpoFunc(double value, double _coef = 1)
        {
            a = value;
            coef = _coef;
        }
    }

    class LogFunc : FunctionClass // не готово
    {
        double a;

        double coef;

        public override double getValue(double x = 2)
        {
            if (a > 0 && a != 1 && x > 0) // ?? мб поменять условие
                return coef * Math.Log(x, a);
            else return 0; // надо изменить на что-нибудь более говорящее
        }

        public override FunctionClass getDerivative()
        {
            return new LogFunc(a - 1, a * coef);
        }

        LogFunc(double value, double _coef = 1)
        {
            a = value; // должно быть больше нуля
            coef = _coef;
        }
    }



    class DerLog : FunctionClass // производная от логарифма, вспомогательная, недоделанная
    {
        double a;

        double coef;

        public override double getValue(double x = 0)
        {
            return coef / (Math.Log(a, Math.E) * x); // x должен быть больше нуля
        }

        public override FunctionClass getDerivative()
        {
            return null;
        }

        DerLog(double value, double _coef = 1)
        {
            a = value; // должно быть больше нуля
            coef = _coef;
        }
    }*/
}
