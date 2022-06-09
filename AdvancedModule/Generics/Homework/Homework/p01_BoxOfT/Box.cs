using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T> where T : class
    {
        private List<T> contents;

        public int Count 
        {
            get
            {
                return contents.Count;
            }
        }

        public void Add(T element)
        {
            contents.Add(element);
        }

        public T Remove()
        {
            if(contents.Count == 0)
            {
                throw new InvalidOperationException("The box is empty");
            }

            T element = contents[contents.Count - 1]; ;
            contents.RemoveAt(contents.Count - 1);

            return element;
        }
    }
}
