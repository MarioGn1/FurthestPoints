using FurthestPoint.Core;
using FurthestPoint.Core.Contracts;

namespace FurthestPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
