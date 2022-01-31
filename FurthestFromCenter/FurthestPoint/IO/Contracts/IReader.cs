namespace FurthestPoint.IO.Contracts
{
    internal interface IReader
    {
        internal string Read(string path = "");

        void Dispose();

    }
}
