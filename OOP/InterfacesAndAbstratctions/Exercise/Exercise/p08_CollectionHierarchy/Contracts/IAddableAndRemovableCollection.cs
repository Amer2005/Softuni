using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Contracts
{
    public interface IAddableAndRemovableCollection<T> : IAddableCollection<T>
    {
        T Remove();
    }
}
