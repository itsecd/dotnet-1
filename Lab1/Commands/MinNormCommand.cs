using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;
using Lab1.Matrix;

namespace Lab1.Commands
{
    public class MinNormCommand : Command<MinNormCommand.MinNormSettings>
    {
        public class MinNormSettings : CommandSettings
        {

        }

        private readonly IMatrixRepository _data;

        public MinNormCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinNormSettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AbstractMatrix minMat = null;
            if (_data.Count == 0)
            {
                AnsiConsole.WriteException(new FieldAccessException("Список пуст!"));
                return -1;
            }
            double minNorm = _data[0].Norm();
            int minInd = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Norm() <= minNorm)
                {
                    minNorm = _data[i].Norm();
                    minMat = _data[i];
                    minInd = i;
                }
            }
            if (minMat == null)
            {
                AnsiConsole.WriteException(new ArgumentNullException(nameof(minMat), "Матрица не может быть равна null!"));
                return -1;
            }
            AnsiConsole.Write(new Panel($"{minInd} {minMat}"));
            return 0;
        }
    }
}