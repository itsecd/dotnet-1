using System;
using System.Linq;
using Lab1.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Lab1.Repository;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMatricesRepository, XmlMatricesRepository>();

            IMatricesRepository xmlMatricesRepository = new XmlMatricesRepository();            
        }
    }

    
}
