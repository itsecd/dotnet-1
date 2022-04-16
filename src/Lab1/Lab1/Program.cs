using Spectre.Console;
using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = AnsiConsole.Prompt(prompt: new SelectionPrompt<string>()
                .Title("11")
                .AddChoices<string>("константа", "показательная"));
                
            AnsiConsole.MarkupLine("[blue]Hello World![/]");
        }
    }
}
