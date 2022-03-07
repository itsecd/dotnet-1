using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class InsertCommand : Command<InsertCommand.InsertSettings>
    {

        public class InsertSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationRepository;

        public InsertCommand(IOperationRepository operationsRepository)
        {
            _operationRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertSettings settings)
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

            var strIndex = new TextPrompt<int>("[green]Введите индекс, по которому вставить операцию: [/]");
            int index = AnsiConsole.Prompt(strIndex);

            _operationRepository.Insert(index, operation);

            return 0;
        }

    }
}