using FurthestPoint.IO.Contracts;
using System;

namespace FurthestPoint.IO
{
    internal class ConsoleWriter : IWriter
    {
        void IWriter.Write(string text, string path)
        {
            Console.WriteLine(text);
        }
    }
}
