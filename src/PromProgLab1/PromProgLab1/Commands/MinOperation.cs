using PromProgLab1.Model;
using PromProgLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProgLab1.Commands
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
            return 0;
        }
    }
}
