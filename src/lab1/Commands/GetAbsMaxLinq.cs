using lab1.Model;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using lab1.PrintMatrix;
using System.Text;
using System.Linq;

namespace Lab1.Commands
{
    public class GetAbsMaxLinqCommand : Command<GetAbsMaxLinqCommand.GetAbsMaxLinqSettings>
    {

        public class GetAbsMaxLinqSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public GetAbsMaxLinqCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAbsMaxLinqSettings settings)
        {
            var matrices = _matricesRepository.GetAll();
            if (matrices.Count == 0)
                return 0;

            IMatrix? resMatrix = matrices.OrderBy( Matrix => Matrix.GetAbsMax()).First();

            if (resMatrix == null)
                return -1;

            AnsiConsole.MarkupLine($"[blue]Min max abs: {resMatrix.GetAbsMax()} [/]");
            AnsiConsole.MarkupLine($"[blue]Matrix: [/]");
            PrintMatrix.Print(resMatrix);

            return 0;
        }

    }
}