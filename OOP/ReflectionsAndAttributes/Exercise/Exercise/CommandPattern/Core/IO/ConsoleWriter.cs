using CommandPattern.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
