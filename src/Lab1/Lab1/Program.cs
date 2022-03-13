using System;
//using Functions;
using System.Collections.Generic;
using Spectre.Console;
using Lab1.FunctionsRepository;

//using System.Xml;
// using Math;

//using Lab1.Menu;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Lab1.Commands;
using Spectre.Console.Cli;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu.MainMenu();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFunctionsRepository, XMLFunctionsRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFunctionCommand>("add");
                config.AddCommand<ClearFunctionCommand>("clear");
                config.AddCommand<MenuFunctionCommand>("menu");
                config.AddCommand<CompareFunctionCommand>("compare");
                config.AddCommand<CountFunctionCommand>("count");
                config.AddCommand<DeleteFunctionCommand>("delete");
                config.AddCommand<WriteFunctionCommand>("write");
            });

            app.Run(args);

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
