using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class RemoveMatrixCommand : Command<RemoveMatrixCommand.RemoveMatrixSettings>
    {
        public class RemoveMatrixSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public RemoveMatrixCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveMatrixSettings settings)
        {
            if (_matricesRepository.GetMatrices().Count == 0)
            {
                AnsiConsole.MarkupLine($"[red]Репозиторий пуст[/]");
                return 0;
            }

            _matricesRepository.PrintMatrices();

            int index;
            do
            {
                index = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс для вставки матрицы"));
            } while (index >= _matricesRepository.GetMatrices().Count);

            _matricesRepository.RemoveMatrix(index);
            return 0;
        }
    }
}