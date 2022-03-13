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
    class MenuFunctionCommand : Command<MenuFunctionCommand.MenuFunctionSettings>
    {
        public class MenuFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository functionRepository;

        public MenuFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MenuFunctionSettings settings)
        {
            Lab1.Menu.Menu.MainMenu(ref functionRepository);

            return 0;
        }
    }
}
