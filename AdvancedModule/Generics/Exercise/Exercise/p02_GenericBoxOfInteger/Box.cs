using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInt
{
    public class Box<T>
    {
        public T Element { get; set; }

        public Box(T element)
        {
            Element = element;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
