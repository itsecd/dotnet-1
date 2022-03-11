using System;
//using Functions;
using System.Collections.Generic;

//using System.Xml;
// using Math;

using MenuSpace;

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

            Menu.MainMenu();
            File.Wr
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
