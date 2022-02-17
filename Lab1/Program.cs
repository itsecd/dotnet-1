using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Matrix> matrices = new();
            bool exitApp = false;
            while (!exitApp)
            {
                string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[bold]Меню[/]")
                .AddChoices( new[] {
                    "Создать матрицу",
                    "Удалить матрицу",
                    "Очистить список",
                    "Сравнить две матрицы",
                    "Показать список",
                    "Выход"
                }));

                switch (choice)
                {
                    case "Создать матрицу":
                        AnsiConsole.Clear();
                        int tw = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во столбцов: "));
                        int th = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во строк: "));
                        if (tw < 1 || th < 1)
                        {
                            AnsiConsole.MarkupLine("[#ff7d00]Недопустимый размер матрицы![/]");
                            break;
                        }
                        matrices.Add(new BufferedMatrix(th, tw));
                        break;
                    case "Удалить матрицу":
                        AnsiConsole.Clear();
                        if (matrices.Count == 0)
                        {
                            AnsiConsole.Write(new Panel("[#ff7d00]Список пуст![/]"));
                            AnsiConsole.WriteLine();
                            break;
                        }
                        AnsiConsole.MarkupLine($"Всего {matrices.Count} матриц в списке");
                        int indDel = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
                        if (indDel < 0 || indDel > matrices.Count - 1)
                        {
                            AnsiConsole.Write(new Panel("[#ff7d00]Индекс вышел за границы списка![/]"));
                            AnsiConsole.WriteLine();
                            break;
                        }
                        matrices.RemoveAt(indDel);
                        AnsiConsole.Write(new Panel("[yellow]Матрица удалена[/]"));
                        break;
                    case "Очистить список":
                        AnsiConsole.Clear();
                        matrices.Clear();
                        AnsiConsole.Write(new Panel("[yellow]Список очищен[/]"));
                        AnsiConsole.WriteLine();
                        break;
                    case "Сравнить две матрицы":
                        AnsiConsole.Clear();
                        int indL = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой матрицы: "));
                        int indR = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй матрицы: "));
                        if (indL < 0 || indL > matrices.Count - 1 || indR < 0 || indR > matrices.Count - 1)
                        {
                            AnsiConsole.Write(new Panel("[#ff7d00]Индекс вышел за границы списка![/]"));
                            AnsiConsole.WriteLine();
                            break;
                        }
                        if (matrices[indL].Equals(matrices[indR]))
                            AnsiConsole.Write(new Panel("[yellow]Матрицы равны[/]"));
                        else
                            AnsiConsole.Write(new Panel("[yellow]Матрицы НЕ равны[/]"));
                        AnsiConsole.WriteLine();
                        break;
                    case "Показать список":
                        AnsiConsole.Clear();
                        if (matrices.Count == 0)
                        {
                            AnsiConsole.Write(new Panel("[#ff7d00]Список пуст![/]"));
                            AnsiConsole.WriteLine();
                            break;
                        }
                        var tmpTab = new Table();
                        tmpTab.AddColumns(new[] {"№", "Матрица"});
                        for (int i = 0; i < matrices.Count; i++)
                            tmpTab.AddRow(new[] {$"[bold blue]{i}[/]", matrices[i].ToString()});
                        AnsiConsole.Write(tmpTab);
                        AnsiConsole.WriteLine();
                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Выключаюсь...[/]");
                        exitApp = true;
                        break;
                }
            }
        }
    }
}
