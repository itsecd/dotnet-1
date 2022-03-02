using System;
using System.Collections.Generic;
using System.Xml.Linq;
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
            var testmat1 = new SparseMatrix(2,2);
            testmat1[0,0] = 1.23;
            testmat1[1,1] = 3.21;
            data.Insert(testmat1, 0);
            var testmat2 = new BufferedMatrix(3,3);
            testmat2[1,1] = 3.45;
            testmat2[2,2] = 5.43;
            data.Insert(testmat2, 0);

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
                        break;
                    case "Очистить список":
                        data.Clear();
                        break;
                    case "Сравнить две матрицы":
                        AnsiConsole.MarkupLine($"Всего матриц в списке: {data.Count}");
                        int indL = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой матрицы: "));
                        int indR = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй матрицы: "));
                        if (data.Compare(indL, indR) == 1)
                            AnsiConsole.Write(new Panel("[yellow]Матрицы равны[/]"));
                        if (data.Compare(indL, indR) == 0)
                            AnsiConsole.Write(new Panel("[yellow]Матрицы НЕ равны[/]"));
                        if (data.Compare(indL, indR) == -1)
                            AnsiConsole.Write(warningIndex);
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
                        AnsiConsole.Write(new Panel("[red]Выключаюсь...[/]"));
                        exitApp = true;
                        break;
                }
            }
            data.Dump();
        }
    }
}
