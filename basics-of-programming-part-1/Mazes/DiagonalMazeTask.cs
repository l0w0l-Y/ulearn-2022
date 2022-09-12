namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            if (width > height)
            {
                robot.MoveDiagonal(width, height,
                    Direction.Right, Direction.Down);
            }
            else
            {
                robot.MoveDiagonal(height, width,
                    Direction.Down, Direction.Right);
            }
        }

        private static void MoveDirection(this Robot robot, int stepCount, Direction direction)
        {
            for (var i = 0; i < stepCount; i++)
            {
                robot.MoveTo(direction);
            }
        }

        private static void MoveDiagonal(this Robot robot, int longestSide, int smallestSide,
            Direction longestDirection, Direction smallestDirection)
        {
            var stepsCount = (longestSide - 3) / (smallestSide - 3);
            for (var i = 0; i <= smallestSide - 3; i++)
            {
                robot.MoveDirection(stepsCount, longestDirection);
                if (i < smallestSide - 3) robot.MoveDirection(1, smallestDirection);
            }
        }
    }
}