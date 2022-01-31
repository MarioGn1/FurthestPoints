using System.Text.RegularExpressions;

namespace FurthestPoint.Core.Contracts
{
    internal interface IController
    {
        MatchCollection GetPointsMatches(string text);
        void SearchFurthestPoints(MatchCollection points);
        string Report();
    }
}
