using FurthestPoint.IO.Contracts;
using System.IO;

namespace FurthestPoint.IO
{
    internal class FileReader : IReader
    {
        public void Dispose()
        {
            this.Dispose();
        }

        string IReader.Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
