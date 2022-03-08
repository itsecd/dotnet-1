using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class ModifyMatrixCommand : Command<ModifyMatrixCommand.ModifyMatrixSettings>
    {
        public class ModifyMatrixSettings : CommandSettings
        {

        }

        private readonly IMatrixRepository _data;

        public ModifyMatrixCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ModifyMatrixSettings settings)
        {
            _data.Load();
            if (_data.Count == 0)
            {
                AnsiConsole.Write(new Panel("[yellow]Список пуст, попробуйте сначала добавить матрицу с помощью команды [bold green]add[/][/]"));
                return -1;
            }
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(_data.ToTable());
                int indMod = AnsiConsole.Prompt(new TextPrompt<int>("Индекс (-1 для выхода из меню):"));
                if (indMod < -1 || indMod >= _data.Count)
                {
                    AnsiConsole.MarkupLine("[yellow]Недопустимое значение индекса![/]");
                    continue;
                }
                if (indMod == -1)
                    break;
                AnsiConsole.MarkupLine("Режим редактирования. Формат ввода: i;j;value.\nДля выхода введите 'q'.");
                while (true)
                {
                    string userinput = AnsiConsole.Prompt(new TextPrompt<string>(">>>"));
                    
                }
            }
            return 0;
        }
    }
}