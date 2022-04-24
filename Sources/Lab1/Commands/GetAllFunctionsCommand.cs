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
    public class GetAllFunctionsCommand : Command<GetAllFunctionsCommand.GetAllFunctionsSettings>
    {
        public class GetAllFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetAllFunctionsCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllFunctionsSettings settings)
        {

            var functions = _functionsRepository.GetFunctions();

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]NameOfFunction[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));

            foreach (Function f in functions)
            {
                switch (f.GetType().Name)
                {
                    case "ConstantFunction":
                        table.AddRow($"[white]{f.GetType().Name}[/]", $"[white]{f.ToString()}[/]");
                        break;
                    case "LinearFunction":
                        table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]");
                        break;
                    case "QuadraticFunction":
                        table.AddRow($"[red]{f.GetType().Name}[/]", $"[red]{f.ToString()}[/]");
                        break;
                    case "SinusFunction":
                        table.AddRow($"[green]{f.GetType().Name}[/]", $"[green]{f.ToString()}[/]");
                        break;
                    case "CosinusFunction":
                        table.AddRow($"[blue]{f.GetType().Name}[/]", $"[blue]{f.ToString()}[/]");
                        break;

                }
                //table.AddRow(f.GetType().Name, f.ToString());
                //AnsiConsole.Write(new Markup($"[blue]{function}[/]"));
            }
            AnsiConsole.Write(table);
            return 0;
        }



    }
}
