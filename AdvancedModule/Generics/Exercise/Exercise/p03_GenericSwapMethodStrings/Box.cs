using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elements)
        {
            Elements = elements;
        }

        public T Element { get; set; }

        public List<T> Elements { get; set; }

        public void Swap(List<T> elements, int firstIndex, int secondIndex)
        {
            T temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var element in Elements)
            {
                result.AppendLine($"{element.GetType()}: {element}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
