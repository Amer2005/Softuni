using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Contracts
{
    public interface IAddableCollection<T>
    {
        public int Add(T item);
    }
}
