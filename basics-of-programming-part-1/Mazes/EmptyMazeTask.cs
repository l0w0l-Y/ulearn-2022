namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            robot.MoveDirection(width - 3, Direction.Right);
            robot.MoveDirection(height - 3, Direction.Down);
        }

        private static void MoveDirection(this Robot robot, int stepCount, Direction direction)
        {
            for (var i = 0; i < stepCount; i++)
            {
                robot.MoveTo(direction);
            }
        }
    }
}