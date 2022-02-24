using lab1.Repositories;
using System;
using System.ComponentModel;
using Spectre.Console.Cli;
using Spectre.Console;

namespace lab1.Commands
{
    class ShowAllBinaryOperation : Command<ShowAllBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("-c|--count <COUNT>")]
            [Description("Max visibles elements on screen.")]
            [DefaultValue(10)]
            public int countVisible { get; set; }
        }

        private readonly IBinaryOperationsRepository _repository;
        public ShowAllBinaryOperation(IBinaryOperationsRepository repository) 
            => _repository = repository ?? throw new ArgumentNullException(nameof(ShowAllBinaryOperation));
        public override int Execute(CommandContext context, Settings settings)
        {
            var operations = _repository.GetAll();

            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Operations");

            foreach (var op in operations)
            {
                table.AddRow(table.Rows.Count.ToString(), op.ToString());

                if ( table.Rows.Count == settings.countVisible)
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

