namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            for (var i = 0; i < height - 3 / 2; i += 2)
            {
                if (!robot.MoveDownNextDirection(height: height, width: width,
                        verticalSteps: i * 2, direction: Direction.Right)) break;
                if (!robot.MoveDownNextDirection(height: height, width: width,
                        verticalSteps: (i + 1) * 2, direction: Direction.Left)) break;
            }
        }

        private static void MoveDirection(this Robot robot, int stepCount, Direction direction)
        {
            for (var i = 0; i < stepCount; i++)
            {
                robot.MoveTo(direction);
            }
        }

        private static bool СanMoveDown(int verticalStepsCount, int height)
        {
            return height > verticalStepsCount + 3;
        }

        private static bool MoveDownNextDirection(this Robot robot, int width, int height,
            int verticalSteps, Direction direction)
        {
            robot.MoveDirection(width - 3, direction);
            if (!СanMoveDown(height: height, verticalStepsCount: verticalSteps)) return false;
            robot.MoveDirection(2, Direction.Down);
            return true;
        }
    }
}