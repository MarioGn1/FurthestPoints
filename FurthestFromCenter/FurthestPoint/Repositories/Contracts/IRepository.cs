using FurthestPoint.Models;
using System.Collections.Generic;

namespace FurthestPoint.Repositories.Contracts
{
    internal interface IRepository
    {
        IReadOnlyCollection<Point> FurthestPoints { get; }
        void Add(Point point);
        void Clear();
    }
}
