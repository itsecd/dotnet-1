using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
{
    public class AddOperationCommand : Command<AddOperationCommand.AddOperationCommandSettings>
    {
        public class AddOperationCommandSettings : CommandSettings
        { }

        private readonly IOperationRepository _operationsRepository;

        public AddOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] AddOperationCommandSettings settings)
        {
            var operationType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                   .Title("Выберите тип операции: ")
                   .AddChoices("Сложение", "Вычитание", "Умножение", "Деление", "Остаток от деления"));

            Operation operation = operationType switch
            {
                "Сложение" => new Addition(),
                "Вычитание" => new Substraction(),
                "Умножение" => new Multiplication(),
                "Деление" => new IntDivision(),
                "Остаток от деления" => new DivisionRemainder(),
                _ => throw new ApplicationException("Неизвестный тип операции")
            };

            var indexPrompt = new TextPrompt<int>("[darkslategray3]Введите индекс, куда хотите вставить операцию: [/]");
            int index = AnsiConsole.Prompt(indexPrompt);
            _operationsRepository.Insert(index, operation);
            return 0;
        }
    }
}