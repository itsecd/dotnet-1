using Spectre.Console;
using System;
using PromProg1.Models;
using PromProg1.Repository;
using System.Collections.Generic;


namespace PromProg1
{
    class Program
    {
        static void Main(string[] args)
        {
            Summation sum1 = new Summation();
            Operation rem1 = new Remainder();

            AnsiConsole.WriteLine($"\n{sum1.GetResult(1,4)}");

            XMLOperationRepository repos = new XMLOperationRepository();

            repos.InsertOperation(0, rem1);
            repos.InsertOperation(2, rem1);
            repos.InsertOperation(1, sum1);
            repos.RemoveOperation(0);
            List<Operation> T = new List<Operation>();
            T = repos.GetOperations();
            Console.WriteLine($"{T[0].ToString()}");
            repos.ClearCollection();
        }
    }
}
