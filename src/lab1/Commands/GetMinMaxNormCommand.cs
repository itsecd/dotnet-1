using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetMinMaxNormCommand : Command<GetMinMaxNormCommand.GetMinMaxNormSettings>
    {

        public class GetMinMaxNormSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public GetMinMaxNormCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetMinMaxNormSettings settings)
        {
            var matrices = _matricesRepository.GetAll();
            if (matrices.Count == 0)
                return 0;

            IMatrix? resMatrix = null;

            var max = Double.PositiveInfinity;
            foreach (var matrix in matrices)
            {
                var matrixMax = matrix.GetMaxNorm();
                if (matrixMax < max)
                {
                    max = matrixMax;
                    resMatrix = matrix;
                }
            }

            if (resMatrix == null)
                return -1;

            AnsiConsole.MarkupLine($"[blue]Min max norm: {max} [/]");
            AnsiConsole.MarkupLine($"[blue]Matrix: [/]");
            PrintMatrixCommand.Print(resMatrix);

            return 0;
        }

    }
}