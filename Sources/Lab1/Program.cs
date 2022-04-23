using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using System.Xml;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] ars)
        {
            var functionRepository = new XmlFunctionsRepository();
            functionRepository.AddFunction(new ConstantFunction(20));
            functionRepository.AddFunction(new LinearFunction(1, 2));
            functionRepository.AddFunction(new QuadraticFunction(1, 2, 0));
            functionRepository.AddFunction(new SinusFunction(-1, 1, 0));
            functionRepository.AddFunction(new CosinusFunction(1, 1, 0));


            var functionType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите вид функции: ")
                .AddChoices("Константа", "Линейная функция", "Квадратичная функция", "Синусоидальная", "Косинусоидальная"));

            Function function = functionType switch
            {
                "Линейная функция" => new LinearFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]"))
                    ),
                "Квадратичная функция" => new QuadraticFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х^2: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]"))
                    ),
                "Синусоидальная" => new SinusFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при sin: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа (фаза): [/]"))
                    ),
                "Косинусоидальная" => new CosinusFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при cos: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Коэффициент при х: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа (фаза): [/]"))),
                _ => new ConstantFunction(
                    AnsiConsole.Prompt(new TextPrompt<double>("[blue]Константа: [/]")))
            };

            functionRepository.AddFunction(function);

            //var table = new Table();
            //table.AddColumn(new TableColumn(new Markup("[white]NameOfFunction[/]")));
            //table.AddColumn(new TableColumn("[white]Function[/]"));

            //foreach (Function f in functions)
            //{
            //    switch (f.GetType().Name)
            //    {
            //        case "ConstantFunction":
            //            table.AddRow($"[white]{f.GetType().Name}[/]", $"[white]{f.ToString()}[/]");
            //            break;
            //        case "LinearFunction":
            //            table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]");
            //            break;
            //        case "QuadraticFunction":
            //            table.AddRow($"[red]{f.GetType().Name}[/]", $"[red]{f.ToString()}[/]");
            //            break;
            //        case "SinusFunction":
            //            table.AddRow($"[green]{f.GetType().Name}[/]", $"[green]{f.ToString()}[/]");
            //            break;
            //        case "CosinusFunction":
            //            table.AddRow($"[blue]{f.GetType().Name}[/]", $"[blue]{f.ToString()}[/]");
            //            break;

            //    }
            //    //table.AddRow(f.GetType().Name, f.ToString());
            //    //AnsiConsole.Write(new Markup($"[blue]{function}[/]"));
            //}
            //AnsiConsole.Write(table);
        }
    }
}

