using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class AddMatrixCommands : Command<AddMatrixCommands.AddMatrixSettings>
    {
        public class AddMatrixSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public override int Execute([NotNull] CommandContext context, [NotNull] AddMatrixSettings settings)
        {
            var matrixType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип матрицы: ")
                .AddChoices("Sparse matrix", "Buffered matrix"));

            Matrix matrix = matrixType switch
            {
                "Sparse matrix" => new SparseMatrix(
                    AnsiConsole.Prompt(new TextPrompt<int>("Высота")),
                    AnsiConsole.Prompt(new TextPrompt<int>("Ширина"))
                ),
                "Buffered matrix" => new SparseMatrix(
                    AnsiConsole.Prompt(new TextPrompt<int>("Высота")),
                    AnsiConsole.Prompt(new TextPrompt<int>("Ширина"))
                ),
                _ => null
            };

            if (matrix == null)
            {
                AnsiConsole.MarkupLine($"[red]Неизвестный тип фигуры {matrixType}[/]");
                return -1;
            }

            _matricesRepository.AddMatrix(matrix);
            return 0;
        }
    }
}
