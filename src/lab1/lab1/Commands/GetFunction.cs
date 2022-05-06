using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace Lab1.Commands
{
    class GetFunction : Command<GetFunction.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("-c|--count <COUNT>")]
            [Description("Max visibles elements on screen.")]
            [DefaultValue(10)]
            public int CountVisible { get; set; }
        }
        private readonly IFunctionRepository _repository;

        public GetFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var functions = _repository.GetAll();

            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Operations");

            foreach (var f in functions)
            {
                table.AddRow(table.Rows.Count.ToString(), f.ToString());

                if (table.Rows.Count == settings.CountVisible)
                {
                    table.AddRow("...");
                    break;
                }
            }

            AnsiConsole.Write(table);

            return 0;
        }
    }
}
