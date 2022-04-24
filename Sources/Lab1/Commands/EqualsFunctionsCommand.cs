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
    public class EqualsFunctionsCommand : Command<EqualsFunctionsCommand.EqualsFunctionsSettings>
    {
        public class EqualsFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public EqualsFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] EqualsFunctionsSettings settings)
        {
            _functionsRepository
            return 0;
        }



    }
}
