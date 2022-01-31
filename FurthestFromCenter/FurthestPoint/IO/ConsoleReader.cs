using FurthestPoint.IO.Contracts;
using System;

namespace FurthestPoint.IO
{
    internal class ConsoleReader : IReader
    {
        private const string noPath = "";
        string IReader.Read(string path)
        {
            return Console.ReadLine();
        }

        void IReader.Dispose()
        {
            Console.ReadKey();
        }
    }
}
