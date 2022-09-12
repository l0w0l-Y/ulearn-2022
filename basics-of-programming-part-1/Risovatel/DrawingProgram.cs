using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    static class Painter
    {
        private static Graphics graphics;

        internal static void Init(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        internal static void PaintLineAngle(Pen pen, double length, double angle)
        {
            var newCoordinate = Position.GetCoordinateRotation(length, angle);
            graphics.DrawLine(pen, Position.Coordinate.CoordinateX, Position.Coordinate.CoordinateY,
                newCoordinate.CoordinateX, newCoordinate.CoordinateY);
            Position.Coordinate.SetCoordinate(newCoordinate.CoordinateX, newCoordinate.CoordinateY);
        }
    }

    class Position
    {
        internal static Coordinate Coordinate = new Coordinate(0, 0);

        internal static void SetPositionRotation(double length, double angle)
        {
            var newCoordinate = GetCoordinateRotation(length, angle);
            Coordinate.CoordinateX = newCoordinate.CoordinateX;
            Coordinate.CoordinateY = newCoordinate.CoordinateY;
        }

        internal static void SetCoordinate(float coordinateX, float coordinateY)
        {
            Coordinate = new Coordinate(coordinateX, coordinateY);
        }

        internal static Coordinate GetCoordinateRotation(double length, double angle)
        {
            return new Coordinate(
                (float)(Coordinate.CoordinateX + length * Math.Cos(angle)),
                (float)(Coordinate.CoordinateY + length * Math.Sin(angle))
            );
        }
    }

    class Coordinate
    {
        internal float CoordinateX;
        internal float CoordinateY;

        internal Coordinate(float coordinateX, float coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        internal void SetCoordinate(float newCoordinateX, float newCoordinateY)
        {
            CoordinateX = newCoordinateX;
            CoordinateY = newCoordinateY;
        }
    }

    public static class ImpossibleSquare
    {
        private static readonly Pen PenColor = Pens.Yellow;

        internal static void Draw(int width, int height, double rotationAngle, Graphics graphics)
        {
            Painter.Init(graphics);

            var size = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;

            Position.SetCoordinate(
                (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f,
                (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f
            );

            PaintSide(
                size: size,
                angles: new[] { 0, Math.PI / 4, Math.PI, Math.PI / 2, -Math.PI, 3 * Math.PI / 4 }
            );

            PaintSide(
                size: size,
                angles: new[]
                {
                    -Math.PI / 2, -Math.PI / 2 + Math.PI / 4, -Math.PI / 2 + Math.PI, -Math.PI / 2 + Math.PI / 2,
                    -Math.PI / 2 - Math.PI, -Math.PI / 2 + 3 * Math.PI / 4
                }
            );

            PaintSide(
                size: size,
                angles: new[]
                {
                    Math.PI, Math.PI + Math.PI / 4, Math.PI + Math.PI, Math.PI + Math.PI / 2, Math.PI - Math.PI,
                    Math.PI + 3 * Math.PI / 4
                }
            );

            PaintSide(
                size: size,
                angles: new[]
                {
                    Math.PI / 2, Math.PI / 2 + Math.PI / 4, Math.PI / 2 + Math.PI, Math.PI / 2 + Math.PI / 2,
                    Math.PI / 2 - Math.PI, Math.PI / 2 + 3 * Math.PI / 4
                }
            );
        }

        private static void PaintSide(int size, double[] angles)
        {
            if (angles.Length != 6) return;
            Painter.PaintLineAngle(PenColor, size * 0.375f, angles[0]);
            Painter.PaintLineAngle(PenColor, size * 0.04f * Math.Sqrt(2), angles[1]);
            Painter.PaintLineAngle(PenColor, size * 0.375f, angles[2]);
            Painter.PaintLineAngle(PenColor, size * 0.375f - size * 0.04f, angles[3]);
            Position.SetPositionRotation(size * 0.04f, angles[4]);
            Position.SetPositionRotation(size * 0.04f * Math.Sqrt(2), angles[5]);
        }
    }
}