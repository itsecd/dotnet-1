using iProg1.Repositories;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace iProg1.Commands
{
    public class OutputAllMatrixCommand : Command<OutputAllMatrixCommand.OutputAllMatrixSettings>
    {
        public class OutputAllMatrixSettings : CommandSettings
        {
        }
       
        private readonly IMatrixRepository _matrixRepository;
        
        public OutputAllMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] OutputAllMatrixSettings settings)
        {
            _matrixRepository.OutputAllMatrix();
            return 1;
        }
    }
}
