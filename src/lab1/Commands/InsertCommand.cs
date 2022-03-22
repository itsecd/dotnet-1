using lab1.Model;
using lab1.Repositories;
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

        private readonly IMatrixRepository _matricesRepository;

        public InsertCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] InsertSettings settings)
        {
            var matrixType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]Select type of matrix: [/]")
                .AddChoices("buffered", "sparse"));

            var height = AnsiConsole.Prompt(new TextPrompt<uint>("[blue]Height: [/]"));
            var width = AnsiConsole.Prompt(new TextPrompt<uint>("[blue]Width: [/]"));

            var numbers = new double[height, width];
            for (var i = 0; i < height; ++i)
                for (var j = 0; j < width; ++j)
                {
                    numbers[i, j] = AnsiConsole.Prompt(new TextPrompt<double>($"[blue]{i}, {j}: [/]"));
                }

            IMatrix? matrix = matrixType switch
            {
                "buffered" => new BufferedMatrix(numbers),
                "sparse" => new SparseMatrix(numbers),
                _ => null
            };

            if (matrix == null)
            {
                AnsiConsole.MarkupLine($"[red]Unknown type: {matrixType}[/]");
                return -1;
            }

            AnsiConsole.MarkupLine($"[blue]Count matrix in collection: {_matricesRepository.GetAll().Count} [/]");
            var index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter index to insert matrix: [/]"));

            _matricesRepository.Insert(index, matrix);

            return 0;
        }

    }
}