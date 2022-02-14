using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BufferedMatrix> matrices = new List<BufferedMatrix>();
            bool exitApp = false;
            while (!exitApp)
            {
                var action = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[bold]Меню[/]")
                    .AddChoices(new[] {
                        "Добавить матрицу",
                        "Удалить матрицу",
                        "Очистить список",
                        "Сравнить пару матриц",
                        "Вывести список на экран",
                        "Выход"
                    })
                );
                switch (action)
                {
                    case "Добавить матрицу":
                        int tw = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во столбцов: "));
                        int th = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во строк: "));
                        if (tw < 1 || th < 1)
                        {
                            AnsiConsole.MarkupLine("[#ff8800]Недопустимое значение![/]\n");
                            break;
                        }
                        var tmpMat = new BufferedMatrix(tw, th);
                        matrices.Add(tmpMat);
                        AnsiConsole.MarkupLine($"Добавлено: [blue]{tmpMat.ToString()}[/]\n");
                        break;
                    case "Удалить матрицу":
                        break;
                    case "Очистить список":
                        matrices.Clear();
                        AnsiConsole.Write(new Panel("[#ffaa00]Список очищен[/]"));
                        break;
                    case "Сравнить пару матриц":
                        break;
                    case "Вывести список на экран":
                        if (matrices.Count == 0)
                        {
                            AnsiConsole.Write(new Panel("[#ff8800]Список пуст![/]"));
                            break;
                        }
                        var matTable = new Table();
                        matTable.AddColumn("№");
                        matTable.AddColumn("Матрица");
                        for (int i = 0; i < matrices.Count; i++)
                            matTable.AddRow($"[bold blue]{i}[/]", matrices[i].ToString());
                        AnsiConsole.Write(matTable);
                        break;
                    case "Выход":
                        AnsiConsole.MarkupLine("[#880000]Выключаюсь...[/]");
                        exitApp = true;
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
