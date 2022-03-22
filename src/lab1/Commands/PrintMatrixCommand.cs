using lab1.Model;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using lab1.PrintMatrix;

namespace Lab1.Commands
{
    public class PrintMatrixCommand : Command<PrintMatrixCommand.PrintMatrixSettings>
    {

        public class PrintMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public PrintMatrixCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintMatrixSettings settings)
        {
            AnsiConsole.MarkupLine($"[blue]Count matrix in collection: {_matricesRepository.GetAll().Count} [/]");
            var index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter index to print matrix: [/]"));
            var matrix = _matricesRepository.GetMatrix(index);

            PrintMatrix.Print(matrix);
            return 0;
        }

    }
}