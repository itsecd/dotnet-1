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
using Lab1.Menu;

namespace Lab1.Commands
{
    class AddFunctionCommand : Command<AddFunctionCommand.AddFunctionSettings>
    {
        public class AddFunctionSettings : CommandSettings
        {
        }

        //private readonly IFunctionsRepository functionRepository;
        private IFunctionsRepository functionRepository;

        public AddFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFunctionSettings settings)
        {
            //throw new NotImplementedException();
            Menu.Menu.AddMenu(ref functionRepository);

            return 0;
        }

    }
}
