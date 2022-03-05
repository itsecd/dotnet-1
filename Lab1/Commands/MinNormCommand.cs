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

        private IMatrixRepository _data;

        public MinNormCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MinNormSettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            double minNorm = _data[0].Norm();
            AbstractMatrix minMat = null;
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
            AnsiConsole.Write(new Panel($"{minInd} {minMat.ToString()}"));
            return 0;
        }
    }
}