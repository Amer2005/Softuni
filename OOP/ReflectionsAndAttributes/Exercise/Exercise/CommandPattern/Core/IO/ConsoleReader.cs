using CommandPattern.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
