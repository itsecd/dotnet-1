using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using Lab1.FunctionsRepository;
using Functions;

namespace Lab1.Commands
{
    class ClearFunctionCommand: Command<ClearFunctionCommand.ClearFunctionSettings>
    {
        public class ClearFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public ClearFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearFunctionSettings settings)
        {
            Menu.Menu.ClearMenu(ref functionRepository);

            return 0;
        }
    }
}
