﻿using Lab1.Operations;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Linq;

namespace Lab1.Commands
{
    class MinBinaryOperation : Command<MinBinaryOperation.Settings>
    {
        public class Settings : CommandSettings
        {
        }

        private readonly IBinaryOperationsRepository _repository;
        public MinBinaryOperation(IBinaryOperationsRepository repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public override int Execute(CommandContext context, Settings settings)
        {
            return GetMinLINQ();

        }

        private int GetMinLINQ()
        {
            var operations = _repository.GetAll();

            if (operations.Count == 0)
            {
                AnsiConsole.Write("[red]There aren't binary operations in database[/]");
                return 0;
            }

            var firstOperand = AnsiConsole.Prompt(
               new TextPrompt<int>("Enter first integer operand")
                   .ValidationErrorMessage("[red]That's not a valid operand[/]")
                   );

            var secondOperand = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter second integer operand")
                    .ValidationErrorMessage("[red]That's not a valid operand[/]")
                    );

            var minResult = operations.Min(v => v.Calculate(new(firstOperand), new(secondOperand)));

            var minOp = (from o in operations
                         where o.Calculate(new(firstOperand), new(secondOperand)) == minResult
                         select o).FirstOrDefault();

            AnsiConsole.Write($"Minimum binary operation for " +
                $"operands {firstOperand} and" +
                $" {secondOperand} : " + minOp);
            return 0;

        }

        private int GetMinOwn()
        {
            var operations = _repository.GetAll();

            if (operations.Count == 0)
            {
                AnsiConsole.Write("[red]There aren't binary operations in database[/]");
                return 0;
            }

            var firstOperand = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter first integer operand")
                    .ValidationErrorMessage("[red]That's not a valid operand[/]")
                    );

            var secondOperand = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter second integer operand")
                    .ValidationErrorMessage("[red]That's not a valid operand[/]")
                    );

            BinaryOperation minOp = null;
            var minResult = IntOperand.GetMaxValue();

            foreach (var op in operations)
            {
                try
                {
                    var curResult = op.Calculate(new(firstOperand), new(secondOperand));
                    if (curResult < minResult)
                    {
                        minOp = op;
                        minResult = curResult;
                    }
                }
                catch (Exception)
                {
                    AnsiConsole.Write($"[red]One of the operations is invalid. Aborting...[/]");
                    return 0;
                }
            }

            AnsiConsole.Write($"Minimum binary operation for " +
                $"operands {firstOperand} and" +
                $" {secondOperand} : " + minOp);
            return 0;
        }
    }
}
