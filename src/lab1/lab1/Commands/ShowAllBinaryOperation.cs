using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.ComponentModel;

namespace Lab1.Commands
{
    class ShowAllBinaryOperation : Command<ShowAllBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("-c|--count <COUNT>")]
            [Description("Max visibles elements on screen.")]
            [DefaultValue(10)]
            public int CountVisible { get; set; }
        }

        private readonly IBinaryOperationsRepository _repository;
        public ShowAllBinaryOperation(IBinaryOperationsRepository repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public override int Execute(CommandContext context, Settings settings)
        {
            var operations = _repository.GetAll();

            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Operations");

            foreach (var op in operations)
            {
                table.AddRow(table.Rows.Count.ToString(), op.ToString());

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

