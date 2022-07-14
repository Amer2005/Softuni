using p04_WildFarm.Core;
using System;

namespace p04_WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Start();
        }
    }
}
