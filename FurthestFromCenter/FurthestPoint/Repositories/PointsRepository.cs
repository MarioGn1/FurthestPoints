using FurthestPoint.Models;
using FurthestPoint.Repositories.Contracts;
using System.Collections.Generic;

namespace FurthestPoint.Repositories
{
    internal class PointsRepository : IRepository
    {
        private readonly List<Point> _points;
        
        public PointsRepository()
        {
            _points = new List<Point>();
        }

        public IReadOnlyCollection<Point> FurthestPoints => _points;

        void IRepository.Add(Point point)
        {
            _points.Add(point);
        }

        void IRepository.Clear()
        {
            _points.Clear();
        }
    }
}
