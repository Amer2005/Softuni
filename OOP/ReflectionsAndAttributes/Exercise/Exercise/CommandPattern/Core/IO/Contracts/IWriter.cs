using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string value);

        void Write(string value);
    }
}
