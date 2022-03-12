using System;
using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using PromProg1.Models;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class InsertOperationCommand : Command<InsertOperationCommand.InsertOperationSettings>
    {
        public class InsertOperationSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public InsertOperationCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertOperationSettings settings)
        {
            var operationType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип операции: ")
                .AddChoices("Сложение", "Вычитание", "Умножение", "Целочисленное деление", "Остаток от деления"));

            Operation operation = operationType switch
            {
                "Сложение" => new Summation(),
                "Умножение" => new Multiplication(),
                "Вычитание" => new Subtraction(),
                "Остаток от деления" => new Remainder(),
                "Целочисленное деление" => new IntegerDivision(),
                _ => null
            };

            if (operation == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип операции: {operationType}[/]");
                return -1;
            }
            int index;
            while (true)
            {
                AnsiConsole.MarkupLine("Введите индекс");
                string strIndex = Console.ReadLine();
                if (int.TryParse(strIndex, out index))
                {
                    _operationsRepository.InsertOperation(index, operation);
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("Введенный индекс не является целым числом\n");
                }
            }
            
            return 0;
        }
    }
}
