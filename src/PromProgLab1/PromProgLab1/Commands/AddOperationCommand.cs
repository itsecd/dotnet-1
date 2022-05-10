using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
{
    public class AddOperationCommand : Command<AddOperationCommand.AddOperationSettings>
    {
        public class AddOperationSettings : CommandSettings
        { }

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

            Operation? operation = operationType switch
            {
                "Сложение" => new Addition(),
                "Вычитание" => new Substraction(),
                "Умножение" => new Multiplication(),
                "Деление" => new IntDivision(),
                "Остаток от деления" => new DivisionRemainder(),
                _ => null
            };

            if (operation == null)
            {
                AnsiConsole.MarkupLine($"[orange]Неизвестный тип операции! [/]");
                return -1;
            }
            var textInsert = new TextPrompt<int>("[darkslategray3]Введите индекс, куда хотите вставить операцию: [/]");
            int index = AnsiConsole.Prompt(textInsert);
            _operationsRepository.Insert(index, operation);
            return 0;
        }
    }
}