using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Contracts
{
    public interface IAddableRemovableAndUsableCollection<T> : IAddableAndRemovableCollection<T>
    {
        int Used { get;}
    }
}
