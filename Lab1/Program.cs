using System;
using Spectre.Console;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold]Меню[/]")
                .AddChoices(new[] {
                    "Создать матрицу",
                    "Удалить матрицу",
                    "Очистить коллекцию",
                    "Сравнить пару матриц",
                    "Вывести коллекцию на экран"
                })
            );
        }
    }
}
