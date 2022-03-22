using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class AddMatrixCommand : Command<AddMatrixCommand.AddMatrixSettings>
    {
        public class AddMatrixSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public AddMatrixCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddMatrixSettings settings)
        {
            var matrixType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип матрицы: ")
                .AddChoices("Sparse matrix", "Buffered matrix"));




            Matrix matrix = matrixType switch
            {
                "Sparse matrix" => new SparseMatrix(
                    AnsiConsole.Prompt(new TextPrompt<int>("Высота")),
                    AnsiConsole.Prompt(new TextPrompt<int>("Ширина")),
                    true
                ),
                "Buffered matrix" => new BufferedMatrix(
                    AnsiConsole.Prompt(new TextPrompt<int>("Высота")),
                    AnsiConsole.Prompt(new TextPrompt<int>("Ширина")),
                    true
                ),
                _ => null
            };

            if (matrix == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип фигуры {matrixType}[/]");
                return -1;
            }

            if (_matricesRepository.GetMatrices().Count() == 0)
            {
                _matricesRepository.AddMatrix(matrix, -1);
                return 0;
            }

            _matricesRepository.PrintMatrices();

            var index = -1;
            do
            {
                index = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс для вставки матрицы"));
            } while (index > _matricesRepository.GetMatrices().Count());

            _matricesRepository.AddMatrix(matrix, index);
            return 0;
        }
    }
}
