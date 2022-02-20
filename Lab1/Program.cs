using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Clear();
            MatrixStorage data = new();
            Panel warningIndex = new Panel("[#ff7d00]Индекс вышел за границы списка![/]");
            Panel warningSize = new Panel("[#ff7d00]Недопустимый размер матрицы![/]");
            Panel warningEmptyList = new Panel("[#ff7d00]Список пуст![/]");

            bool exitApp = false;
            while (!exitApp)
            {
                string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]Меню[/]")
                .AddChoices(new[] {
                    "Создать матрицу",
                    "Удалить матрицу",
                    "Очистить список",
                    "Сравнить две матрицы",
                    "Показать список",
                    "Выход"
                }));
                AnsiConsole.Clear();
                switch (choice)
                {
                    case "Создать матрицу":
                        string matType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("Выберите тип матрицы:")
                        .AddChoices(new[] {
                            "BufferedMatrix",
                            "SparseMatrix"
                        }));
                        int tw = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во столбцов: "));
                        int th = AnsiConsole.Prompt(new TextPrompt<int>("Кол-во строк: "));
                        if (tw < 1 || th < 1)
                        {
                            AnsiConsole.Write(warningSize);
                            AnsiConsole.WriteLine();
                            break;
                        }
                        Matrix tmpMat = matType switch
                        {
                            "BufferedMatrix" => new BufferedMatrix(th, tw),
                            "SparseMatrix" => new SparseMatrix(th, tw),
                            _ => null
                        };
                        AnsiConsole.MarkupLine($"Всего матриц в списке: {data.Count}");
                        int indIns = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
                        data.Insert(tmpMat, indIns);
                        break;
                    case "Удалить матрицу":
                        if (data.Count == 0)
                        {
                            AnsiConsole.Write(warningEmptyList);
                            AnsiConsole.WriteLine();
                            break;
                        }
                        AnsiConsole.MarkupLine($"Всего матриц в списке: {data.Count}");
                        int indDel = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
                        data.Delete(indDel);
                        AnsiConsole.Write(new Panel("[yellow]Матрица удалена[/]"));
                        AnsiConsole.WriteLine();
                        break;
                    case "Очистить список":
                        data.Clear();
                        AnsiConsole.Write(new Panel("[yellow]Список очищен[/]"));
                        AnsiConsole.WriteLine();
                        break;
                    case "Сравнить две матрицы":
                        AnsiConsole.MarkupLine($"Всего матриц в списке: {data.Count}");
                        int indL = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой матрицы: "));
                        int indR = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй матрицы: "));
                        if (data.Compare(indL, indR))
                            AnsiConsole.Write(new Panel("[yellow]Матрицы равны[/]"));
                        else
                            AnsiConsole.Write(new Panel("[yellow]Матрицы НЕ равны[/]"));
                        AnsiConsole.WriteLine();
                        break;
                    case "Показать список":
                        if (data.Count == 0)
                        {
                            AnsiConsole.Write(warningEmptyList);
                            AnsiConsole.WriteLine();
                            break;
                        }
                        AnsiConsole.Write(data.ToTable());
                        AnsiConsole.WriteLine();
                        break;
                    default:
                        AnsiConsole.Write(new Panel("[bold red]Выключаюсь...[/]"));
                        exitApp = true;
                        break;
                }
            }
        }
    }
}
