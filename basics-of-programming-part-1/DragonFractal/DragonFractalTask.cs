using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        private static readonly double Cos45 = Math.Cos(45 * Math.PI / 180);
        private static readonly double Sin45 = Math.Sin(45 * Math.PI / 180);
        private static readonly double Cos135 = Math.Cos(135 * Math.PI / 180);
        private static readonly double Sin135 = Math.Sin(135 * Math.PI / 180);

        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var coordinate = (1.0, 0.0);
            (double, double) newCoordinate;
            var random = new Random(seed);
            for (var i = 0; i < iterationsCount; i++)
            {
                var nextNumber = random.Next(2);
                switch (nextNumber)
                {
                    case 0:
                        newCoordinate.Item1 = (coordinate.Item1 * Cos45 - coordinate.Item2 * Sin45) / Math.Sqrt(2);
                        newCoordinate.Item2 = (coordinate.Item1 * Sin45 + coordinate.Item2 * Cos45) / Math.Sqrt(2);
                        coordinate = newCoordinate;
                        break;
                    case 1:
                        newCoordinate.Item1 =
                            (coordinate.Item1 * Cos135 - coordinate.Item2 * Sin135) / Math.Sqrt(2) + 1;
                        newCoordinate.Item2 = (coordinate.Item1 * Sin135 + coordinate.Item2 * Cos135) / Math.Sqrt(2);
                        coordinate = newCoordinate;
                        break;
                }

                pixels.SetPixel(coordinate.Item1, coordinate.Item2);
            }
        }
    }
}