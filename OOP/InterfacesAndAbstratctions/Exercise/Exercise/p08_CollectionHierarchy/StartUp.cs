using p08_CollectionHierarchy.Core;
using System;

namespace p08_CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
