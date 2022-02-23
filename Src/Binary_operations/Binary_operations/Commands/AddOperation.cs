using Binary_operations.Models;
using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Binary_operations.Commands
{
    public class AddOperationCommand : Command<AddOperationCommand.AddOperationSettings>
    {
        public class AddOperationSettings : CommandSettings
        {
        }
        private readonly IOperationRepository _operationsRepository;
        public AddOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] AddOperationSettings settings)
        {
            var operationType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                   .Title("Выберите тип операции: ")
                   .AddChoices("Сложение", "Вычитание", "Умножение", "Деление", "Остаток от деления"));
            Operation operation = operationType switch
            {
                "Сложение" => new Addition(
                    AnsiConsole.Prompt(new TextPrompt<int>("[chartreuse1] Левое число: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[chartreuse1] Правое число: [/]"))
                    ),
                "Вычитание" => new Substraction(
                    AnsiConsole.Prompt(new TextPrompt<int>("[greenyellow] Левое число: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[greenyellow] Правое число: [/]"))
                    ),
                "Умножение" => new Multyplication(
                    AnsiConsole.Prompt(new TextPrompt<int>("[darkolivegreen1_1] Левое число: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[darkolivegreen1_1] Правое число: [/]"))
                    ),
                "Деление" => new Division(
                    AnsiConsole.Prompt(new TextPrompt<int>("[green] Левое число: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[green] Правое число: [/]"))
                    ),
                "Остаток от деления" => new Remainder(
                    AnsiConsole.Prompt(new TextPrompt<int>("[palegreen1_1] Левое число: [/]")),
                    AnsiConsole.Prompt(new TextPrompt<int>("[palegreen1_1] Правое число: [/]"))
                    ),
                _ => null
            };
            if (operationType == null)
            {
                AnsiConsole.MarkupLine($"[orange]Неизвестный тип фигуры: {operationType}[/]");
                return -1;
            }
            var text_insert = new TextPrompt<int>("[darkslategray3]Введите индекс, куда хотите вставить операцию: [/]");
            int index = AnsiConsole.Prompt(text_insert);
            _operationsRepository.AddOperation(index, operation);
            return 0;
        }


    }
}
