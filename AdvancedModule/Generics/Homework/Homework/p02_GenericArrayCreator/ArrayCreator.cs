using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            T[] result = new T[lenght];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = item;
            }

            return result;
        }
    }
}
