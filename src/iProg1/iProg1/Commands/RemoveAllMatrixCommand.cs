using iProg1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iProg1.Commands
{
    public class RemoveAllMatrixCommand: Command<RemoveAllMatrixCommand.RemoveAllMatrixSettings>
    {
        public class RemoveAllMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matrixRepository;
        
        public RemoveAllMatrixCommand(IMatrixRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllMatrixSettings settings)
        {
            if(AnsiConsole.Confirm("Remove all matrices?"))
            {
                _matrixRepository.RemoveAllMatrix();
                return 1;
            }
            else
            {
                return -10;
            }
        }
    }
}
