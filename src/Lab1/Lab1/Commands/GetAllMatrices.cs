using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class GetAllMatricesCommand : Command<GetAllMatricesCommand.GetAllMatricesSettings>
    {
        public class GetAllMatricesSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public GetAllMatricesCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllMatricesSettings settings)
        {
            var matrices = _matricesRepository.GetMatrices();

            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Size");
            table.AddColumn("Value");

            var count = 0;

            foreach (Matrix matrix in matrices)
            {
                count++;
                table.AddRow(matrix.GetType().Name, matrix.GetMatrixSize().ToString(), matrix.ToString());
                if (count == 10)
                {
                    table.AddRow(". . .", "", "");
                    break;
                }
            }

            AnsiConsole.Write(table);

            return 0;
        }
    }
}
