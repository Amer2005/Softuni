using p08_CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Models
{
    public class AddableRemovableAndUsableCollection<T> : IAddableRemovableAndUsableCollection<T>
    {
        private List<T> collection;

        public AddableRemovableAndUsableCollection()
        {
            collection = new List<T>();
        }

        public int Used => collection.Count;

        public int Add(T item)
        {
            collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T removedItem = collection[0];

            collection.RemoveAt(0);

            return removedItem;
        }
    }
}
