using lab1.Model;
using lab1.PrintMatrix;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetAbsMaxCommand : Command<GetAbsMaxCommand.GetAbsMaxSettings>
    {

        public class GetAbsMaxSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public GetAbsMaxCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAbsMaxSettings settings)
        {
            var max = Double.PositiveInfinity;
            var matrices = _matricesRepository.GetAll();
            if (matrices.Count == 0)
                return 0;

            IMatrix? resMatrix = null;

            foreach(var matrix in matrices)
            {
                var matrixMax = matrix.GetAbsMax();
                if (matrixMax < max)
                {
                    max = matrixMax;
                    resMatrix = matrix;
                }
            }

            if (resMatrix == null)
                return -1;

            AnsiConsole.MarkupLine($"[blue]Min max abs: {max} [/]");
            AnsiConsole.MarkupLine($"[blue]Matrix: [/]");
            PrintMatrix.Print(resMatrix);

            return 0;
        }

    }
}