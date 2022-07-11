using System;
using System.Collections.Generic;
using System.Text;
using p08_CollectionHierarchy.Contracts;

namespace p08_CollectionHierarchy.Models
{
    public class AddableAndRemovableCollcetion<T> : IAddableAndRemovableCollection<T>
    {
        private List<T> collection;

        public AddableAndRemovableCollcetion()
        {
            collection = new List<T>();
        }

        public int Add(T item)
        {
            collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T removedItem = collection[collection.Count - 1];

            collection.RemoveAt(collection.Count - 1);

            return removedItem;
        }
    }
}
