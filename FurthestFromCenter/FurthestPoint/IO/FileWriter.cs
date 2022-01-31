using FurthestPoint.IO.Contracts;
using System.IO;

namespace FurthestPoint.IO
{
    internal class FileWriter : IWriter
    {
        void IWriter.Write(string text, string path)
        {
            File.WriteAllText(path, text);
        }
    }
}
