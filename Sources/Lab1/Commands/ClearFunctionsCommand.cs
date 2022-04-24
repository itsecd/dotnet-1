using Lab1.Models;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class ClearFunctionsCommand : Command<ClearFunctionsCommand.ClearFeaturesSettings>
    {
        public class ClearFeaturesSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public ClearFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] ClearFeaturesSettings settings)
        {
            _functionsRepository.Clear();
            return 0;
        }



    }
}
