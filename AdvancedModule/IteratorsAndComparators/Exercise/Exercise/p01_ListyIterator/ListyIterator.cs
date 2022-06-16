using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] data)
        {
            collection = data.ToList();
            currentIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        public bool HasNext()
        {
            return currentIndex < collection.Count - 1;
        }

        public bool Move()
        {
            bool canMove = HasNext();

            if(canMove)
            {
                currentIndex++;
            }

            return canMove;
        }

        public void Print()
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(collection[currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(String.Join(" ", this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
