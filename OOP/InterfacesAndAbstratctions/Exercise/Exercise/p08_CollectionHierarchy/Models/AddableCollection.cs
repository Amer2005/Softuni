using p08_CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Models
{
    public class AddableCollection<T> : IAddableCollection<T>
    {
        private List<T> collection;

        public AddableCollection()
        {
            collection = new List<T>();
        }

        public int Add(T item)
        {
            collection.Add(item);

            return collection.Count - 1;
        }
    }
}
