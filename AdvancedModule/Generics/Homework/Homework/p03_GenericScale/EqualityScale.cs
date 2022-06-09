using System;
using System.Collections.Generic;
using System.Text;

namespace p03_GenericScale
{
    public class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            Right = right;
            Left = left;
        }

        public T Right { get; set; }

        public T Left { get; set; }

        public bool AreEqual()
        {
            return Left.Equals(Right);
        }
    }
}
