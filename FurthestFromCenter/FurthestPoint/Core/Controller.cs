using FurthestPoint.Core.Contracts;
using FurthestPoint.Models;
using FurthestPoint.Repositories;
using FurthestPoint.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using static FurthestPoint.Utils.Messages.AppConstants;

namespace FurthestPoint.Core
{
    internal class Controller : IController
    {
        private readonly List<int> _points;
        private readonly IRepository pointsRepository;

        public Controller()
        {
            this._points = new List<int>();
            this.pointsRepository = new PointsRepository();
        }

        public MatchCollection GetPointsMatches(string text)
        {
            Regex allPointsPatern = new Regex(REGEX);
            MatchCollection pointsMatches = allPointsPatern.Matches(text);

            if (!pointsMatches.Any())
            {
                throw new ArgumentException(NO_POINTS_EXCEPTION_MSG);                
            }

            return pointsMatches;
        }

        public void SearchFurthestPoints(MatchCollection points)
        {
            foreach (Match match in points)
            {
                int pointNumber = int.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);

                if (_points.Contains(pointNumber))
                {
                    continue;
                }

                _points.Add(pointNumber);

                double[] currPointCoords = match.Groups[2].Value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                    .ToArray();

                double coordX = currPointCoords[0];
                double coordY = currPointCoords[1];

                Point currPoint = new Point
                {
                    Coordinates = match.ToString(),
                    Distance = CalculateDistance(coordX, coordY),
                    Quadrant = CheckQuadrant(coordX, coordY)
                };

                if (!pointsRepository.FurthestPoints.Any())
                {
                    pointsRepository.Add(currPoint);
                    continue;
                }

                if (pointsRepository.FurthestPoints.FirstOrDefault().Equals(currPoint))
                {
                    pointsRepository.Add(currPoint);
                }
                else if (pointsRepository.FurthestPoints.FirstOrDefault().Distance < currPoint.Distance)
                {
                    pointsRepository.Clear();
                    pointsRepository.Add(currPoint);
                }
            }
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, this.pointsRepository.FurthestPoints);
        }

        private  double CalculateDistance(double x, double y)
            => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        private Quadrants CheckQuadrant(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                return Quadrants.Quadrant_I;
            }
            else if (x < 0 && y > 0)
            {
                return Quadrants.Quadrant_II;
            }
            else if (x < 0 && y < 0)
            {
                return Quadrants.Quadrant_III;
            }
            else
            {
                return Quadrants.Quadrant_IV;
            }
        }
    }
}
