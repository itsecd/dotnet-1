using System;
using iProg1.Model;
using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace iProg1.Commands
{
    public class AddMatrixCommand : Command<AddMatrixCommand.AddMatrixSettings>
    {
        public class AddMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matrixRepository;

        public AddMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddMatrixSettings settings)
        {
            var matrixType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select the matrix type: ")
                .AddChoices("Buffered matrix", "Sparse matrix"));
            Matrix matrix = null;
            int dimension = AnsiConsole.Prompt(new TextPrompt<int>("Enter the dimension(< 65536): ")
                .Validate(num => num > 0));
            var wayToFill = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a way to fill in the matrix: ")
                .AddChoices("Automatically(Random (-100; 100))", "Manually"));
            double[][] tmpMatrix = new double[dimension][];
            switch (wayToFill)
            {
                case "Automatically(Random (-100; 100))":
                    Random random = new Random(DateTime.Now.Second);
                    for (int i = 0; i < dimension; i++)
                    {
                        tmpMatrix[i] = new double[dimension];
                        for (int j = 0; j < dimension; j++)
                        {
                            tmpMatrix[i][j] = Math.Round(random.NextDouble() * 100, 5);
                            if (random.Next() % 2 == 1)
                            {
                                tmpMatrix[i][j] *= -1;
                            }
                        }
                    }
                    break;
                case "Manually":
                    for (int i = 0; i < dimension; i++)
                    {
                        tmpMatrix[i] = new double[dimension];
                        for (int j = 0; j < dimension; j++)
                        {
                            AnsiConsole.Clear();
                            AnsiConsole.WriteLine("Enter matrix: ");
                            tmpMatrix[i][j] = AnsiConsole.Ask<double>(Helper.GetCurrentElemsOfMatrix(tmpMatrix, i, j));
                        }
                    }
                    break;
            }
            switch (matrixType)
            {
                case "Buffered matrix":
                    matrix = new BufferedMatrix(tmpMatrix);
                    break;
                case "Sparse matrix":
                    matrix = new SparseMatrix(tmpMatrix);
                    break;
                default:
                    matrix = null;
                    break;
            }
            AnsiConsole.Clear();
            int index = AnsiConsole.Prompt(new TextPrompt<int>("Enter index of the matrix to add(\"-10\" to EXIT): ")
                .ValidationErrorMessage("That's not a valid index")
                .Validate(_matrixRepository.IsIndexInRange));
            if (index == -10)
            {
                return -10;
            }
            if (matrix == null)
            {
                return -1;
            }
            _matrixRepository.AddMatrix(matrix, index);
            return 1;
        }
    }
}
