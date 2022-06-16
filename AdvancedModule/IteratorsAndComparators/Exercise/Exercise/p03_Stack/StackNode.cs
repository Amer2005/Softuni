using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Stack
{
    public class StackNode<T>
    {
        public StackNode(T value)
        {
            Value = value;
        }

        public StackNode<T> Previous { get; set; }

        public T Value { get; set; }
    }
}
