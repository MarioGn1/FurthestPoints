using System.Text;

namespace FurthestPoint.Models
{
    internal class Point
    {
        public string Coordinates { get; set; } = string.Empty;
        public double Distance { get; set; } = 0.0;
        public Quadrants Quadrant { get; set; } = Quadrants.None;

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point m = obj as Point;
                if (m.Distance != this.Distance) return false;

                return true;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Furthest point is: {Coordinates}");
            sb.AppendLine($"Distance: {Distance}");
            sb.AppendLine($"Positioned in: {Quadrant}");
            return sb.ToString();
        }
    }
}
