using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return r1.IsIntersected(r2) || r2.IsIntersected(r1);
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (!AreIntersected(r1, r2)) return 0;
            switch (IndexOfInnerRectangle(r1, r2))
            {
                case 0: return r1.Width * r1.Height;
                case 1: return r2.Width * r2.Height;
            }

            return (Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top)) *
                   (Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left));
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (r1.IsInner(r2)) return 0;
            if (r2.IsInner(r1)) return 1;
            return -1;
        }

        private static bool IsInner(this Rectangle r1, Rectangle r2)
        {
            return r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom;
        }

        private static bool IsIntersected(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left && r1.Left <= r2.Right) && (r2.Bottom >= r1.Top && r2.Top <= r1.Bottom);
        }
    }
}