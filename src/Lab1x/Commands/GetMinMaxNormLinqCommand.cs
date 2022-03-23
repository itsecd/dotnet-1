using Lab1.Repositories;
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
            var matrix = _matricesRepository
                .GetAll()
                .OrderBy(m => m.GetMaxNorm())
                .FirstOrDefault();

            if (matrix is null)
                return 0;

            AnsiConsole.MarkupLine($"[blue]Min max norm: {matrix.GetMaxNorm()} [/]");
            AnsiConsole.MarkupLine($"[blue]Matrix: [/]");
            PrintMatrixCommand.Print(matrix);

            return 0;
        }

    }
}