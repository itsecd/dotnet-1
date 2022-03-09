using Lab1.Model;

namespace Lab1
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Function gg = new Constant(2);
            Function gg1 = new Constant(3);
            Function gg2 = new Constant(4);
            Function gg3 = new Constant(5);

            Function lin = new LinearFunction(2, 8);
            Function qf = new QuadraticFunction(2, 3, 3);


            List<Function> func = new List<Function> { gg, lin, qf, gg3 };

            func.Insert(4, gg2);

            var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип функции: ")
                .AddChoices("Константа", "Линейная функция", "Квадратичная функция", "Синус", "Косинус"));

            Function addFunc = figureType switch
            {
                "Константа" => new Constant(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter value 'c' :[/]"))
                ),
                "Линейная функция" => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'k' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]"))
                ),
                "Квадратичная функция" => new QuadraticFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'a' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'b' :[/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[red]Enter 'c' :[/]"))
                ),
                "Синус" => new Sin(),
                "Косинус" => new Cos(),
                _ => null
            };
            if (addFunc == null)
            {
                AnsiConsole.MarkupLine($"[green]Неизвестный тип функции[/]");
            }
            func.Add(addFunc);

            //var textPrompt = new TextPrompt<double>("[red]Enter a real number:[/]");
            //double val = AnsiConsole.Prompt(textPrompt);

            var table = new Table();
            table.AddColumns("Function", "Data", "Derivative");
            foreach (Function f in func)
            {
                table.AddRow(f.GetType().Name, f.ToString(), f.GetDerivative().ToString());
                //AnsiConsole.Write(new Markup($"[mediumorchid]Function ::: [/][lime]{f}[/]\n"));
            }
            AnsiConsole.Write(table);

            /*
            var minValue = func.Min(x => x.GetDerivative().GetValueFunc(2));
            var funcMinValue = func.First(x => x.GetDerivative().GetValueFunc(2) == minValue);
            Console.WriteLine(funcMinValue);
            Console.WriteLine(GetMinValueDerivative(func, 2));

            Function cs = new Cos();
            Console.WriteLine(cs.GetValueFunc(-10));

            Function sn = new Sin();
            Function sin = new Sin();
            Console.WriteLine(sn.GetValueFunc(10));

            Function test1 = new QuadraticFunction(1, 2, 3);

            Function test2 = new QuadraticFunction(1, 2, 3);
            Console.WriteLine(sn.Equals(sin));
            */
        }

        public static Function GetMinValueDerivative(List<Function> func, double arg)
        {
            if (func.Count == 0) throw new Exception("Your List is empty");
            double min = double.MaxValue;
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().Compute(arg) < min)
                    min = elem.GetDerivative().Compute(arg);
            }
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().Compute(arg) == min)
                    return elem;
            }
            throw new Exception("Unreal ERROR");
        }
    }
}
