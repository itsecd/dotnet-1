using System;
using System.Linq;
using dotnet_1.Matrix;
using System.Xml.Serialization;

namespace dotnet_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BufferedMatrix tmp = new BufferedMatrix(4, 4);
            tmp.Set(2, 2, 2.34);
            Console.WriteLine(tmp.Get(2, 2));
            Console.WriteLine(tmp.ToString());
        }
    }
}
