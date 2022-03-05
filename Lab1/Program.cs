using System;
using Spectre.Console;
using Lab1.Matrix;
using Lab1.Repository;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //инициализация
            AnsiConsole.Clear();
            MatrixStorage data = new();
            data.Load();
            Panel warningIndex = new Panel("[#ff7d00]Индекс вышел за границы списка![/]");
            Panel warningSize = new Panel("[#ff7d00]Недопустимый размер матрицы![/]");
            Panel warningEmptyList = new Panel("[#ff7d00]Список пуст![/]");
            AnsiConsole.Write(data.ToTable());
            

            //главный цикл
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
                        AnsiConsole.Write(data.ToTable());
                        string matType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("Выберите тип матрицы:")
                        .AddChoices(new[] {
                            "BufferedMatrix",
                            "SparseMatrix"
                        }));
                        int tw = AnsiConsole.Prompt(new TextPrompt<int>("Ширина: "));
                        int th = AnsiConsole.Prompt(new TextPrompt<int>("Высота: "));
                        if (tw < 1 || th < 1)
                        {
                            AnsiConsole.WriteException(new ArgumentOutOfRangeException("Недопустимый размер матрицы!"));
                            break;
                        }
                        AbstractMatrix tmpMat = matType switch
                        {
                            "BufferedMatrix" => new BufferedMatrix(th, tw),
                            "SparseMatrix" => new SparseMatrix(th, tw),
                            _ => null
                        };
                        int indIns = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
                        data.Insert(tmpMat, indIns);
                        break;


                    case "Удалить матрицу":
                        AnsiConsole.Write(data.ToTable());
                        int indDel = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
                        data.Delete(indDel);
                        break;


                    case "Очистить список":
                        data.Clear();
                        break;


                    case "Сравнить две матрицы":
                        AnsiConsole.Write(data.ToTable());
                        int indL = AnsiConsole.Prompt(new TextPrompt<int>("Индекс первой матрицы: "));
                        int indR = AnsiConsole.Prompt(new TextPrompt<int>("Индекс второй матрицы: "));
                        if (data.Compare(indL, indR) == 1)
                            AnsiConsole.Write(new Panel("[yellow]Матрицы равны[/]"));
                        if (data.Compare(indL, indR) == 0)
                            AnsiConsole.Write(new Panel("[yellow]Матрицы НЕ равны[/]"));
                        if (data.Compare(indL, indR) == -1)
                            AnsiConsole.Write(warningIndex);
                        break;


                    case "Показать список":
                        AnsiConsole.Write(data.ToTable());
                        break;

                        
                    default:
                        AnsiConsole.Write(new Panel("[red]Выключаюсь...[/]"));
                        AnsiConsole.Write(data.ToTable());
                        data.Dump();
                        exitApp = true;
                        break;
                }
                AnsiConsole.WriteLine();
            }
        }
    }
}
