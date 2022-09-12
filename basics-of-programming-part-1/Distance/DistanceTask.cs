using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            var ab = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
            var bc = Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y));
            var ac = Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
            var p = (ab + bc + ac) / 2;
            var h = 2 * Math.Sqrt(p * (p - ab) * (p - ac) * (p - bc)) / ab;
            if (ab == 0) return ac;
            if (GetCos(bc, ac, ab) < 0) return ac;
            return GetCos(ac, bc, ab) < 0 ? bc : h;
        }

        private static double GetCos(double a, double b, double c)
        {
            return (b * b + c * c - a * a) / (2 * b * c);
        }
    }
}