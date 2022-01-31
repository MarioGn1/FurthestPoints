namespace FurthestPoint.IO.Contracts
{
    internal interface IWriter
    {
        internal void Write(string text, string path = "");
    }
}
