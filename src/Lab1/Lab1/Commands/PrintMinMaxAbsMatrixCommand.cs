using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class PrintMinMaxAbsMatrixCommand : Command<PrintMinMaxAbsMatrixCommand.PrintMinMaxAbsMatrixSettings>
    {
        public class PrintMinMaxAbsMatrixSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public PrintMinMaxAbsMatrixCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintMinMaxAbsMatrixSettings settings)
        {

            double? min = (_matricesRepository.GetMatrices().Any() ?
                _matricesRepository.GetMatrices()[0].GetMaxElm() : null);
            if (min == null)
            {
                AnsiConsole.MarkupLine("[red]Репозиторий пуст[/]");
                return -1;
            }

            foreach (var matrix in _matricesRepository.GetMatrices())
            {
                if (matrix.GetMaxElm() < min)
                    min = matrix.GetMaxElm();
            }
            AnsiConsole.MarkupLine($"[green]Минимальная норма: {min} [/]");

            min = _matricesRepository.GetMatrices()[0].GetMaxElmLinq();
            foreach (var matrix in _matricesRepository.GetMatrices())
            {
                if (matrix.GetMaxElmLinq() < min)
                    min = matrix.GetMaxElmLinq();
            }
            AnsiConsole.MarkupLine($"[green]Минимальная норма Linq: {min} [/]");

            return 0;
        }
    }
}
