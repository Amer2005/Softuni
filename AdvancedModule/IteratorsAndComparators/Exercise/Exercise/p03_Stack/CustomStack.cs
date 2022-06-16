using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace p03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private StackNode<T> top;

        public CustomStack()
        {
            Count = 0;
            top = null;
        }

        public int Count { get; set; }

        public void Push(T value)
        {
            StackNode<T> newTop = new StackNode<T>(value);

            newTop.Previous = top;

            top = newTop;

            Count++;
        }

        public T Pop()
        {
            if (top == null)
            {
                Console.WriteLine("No elements");

                return default;
            }

            T value = top.Value;

            top = top.Previous;

            Count--;

            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            StackNode<T> currentElement = top;
            for (int i = 0; i < Count; i++)
            {
                yield return currentElement.Value;

                currentElement = currentElement.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
