using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using Lab1.Repository;
using Lab1.Model;

namespace Lab1.Commands
{
    public class AddOperationCommand : Command<AddOperationCommand.AddOperationSettings>
    {

        public class AddOperationSettings : CommandSettings
        {
        }

        private readonly IOperationsRepository _operationsRepository;

        public AddOperationCommand(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddOperationSettings settings)
        {
            var operationType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип операции: ")
                .AddChoices("Сложение", "Вычитание", "Умножение", "Целочисленное деление", "Остаток от деления"));

            Operation operation = operationType switch
            {
                "Сложение" => new Sum(),
                "Вычитание" => new Sub(),
                "Умножение" => new Mul(),
                "Целочисленное деление" => new IntDiv(),
                "Остаток от деления" => new DivRemainder(),
                _ => null
            };

            if (operation == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип операции: {operationType}[/]");
                return -1;
            }

            var str_index = new TextPrompt<int>("[green]Введите индекс, по которому вставить операцию: [/]");
            int index = AnsiConsole.Prompt(str_index);

            _operationsRepository.AddOperation(index, operation);

            return 0;
        }

    }
}