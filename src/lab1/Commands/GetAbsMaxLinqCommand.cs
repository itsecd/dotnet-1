using lab1.Model;
using lab1.PrintMatrix;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class GetMinMaxNormLinqCommand : Command<GetMinMaxNormLinqCommand.GetMinMaxNormLinqSettings>
    {

        public class GetMinMaxNormLinqSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public GetMinMaxNormLinqCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetMinMaxNormLinqSettings settings)
        {
            var matrices = _matricesRepository.GetAll();
            if (matrices.Count == 0)
                return 0;

            IMatrix? resMatrix = matrices.OrderBy(Matrix => Matrix.GetMaxNorm()).First();

            if (resMatrix == null)
                return -1;

            AnsiConsole.MarkupLine($"[blue]Min max norm: {resMatrix.GetMaxNorm()} [/]");
            AnsiConsole.MarkupLine($"[blue]Matrix: [/]");
            PrintMatrix.Print(resMatrix);

            return 0;
        }

    }
}