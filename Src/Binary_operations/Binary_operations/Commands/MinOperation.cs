using Binary_operations.Models;
using Binary_operations.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace Binary_operations.Commands
{
    public class MinOperation : Command<MinOperation.MinOperationSettings>
    {
        public class MinOperationSettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public MinOperation(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinOperationSettings settings)
        {
            var leftInsert = new TextPrompt<int>("[green]Введите левое число: [/]");
            int left = AnsiConsole.Prompt<int>(leftInsert);
            var rightInsert = new TextPrompt<int>("[green]Введите правое число: [/]");
            int right = AnsiConsole.Prompt<int>(rightInsert);
            
            AnsiConsole.MarkupLine($"[orange1]Для чисел {left} и {right} минимальной будет операция {_operationsRepository.MinElement(left, right)}[/]");
            AnsiConsole.MarkupLine($"[wheat1]Для чисел {left} и {right} минимальная операция, найденная с помощью Linq: {_operationsRepository.MinElementLinq(left, right)}  [/] ");
            return 0;
        }
    }
}

