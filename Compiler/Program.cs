using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes("Engine.dll")));
            Console.ReadLine();
        }
    }
}
