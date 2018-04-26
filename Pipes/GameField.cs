using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Pipes
{
    class GameField
    {
        public int StepCount { get; set; }

        public readonly Button[,] ButtonsField;
        public readonly Pipe[,] PipesField;

        private readonly int pipeCount;

        private Dictionary<Color, int> countByColor = new Dictionary<Color, int>()
        {
            { Color.Blue, 0 },
            { Color.Green, 0 },
            { Color.Red, 0 },
            { Color.Yellow, 0 }
        };

        public bool IsComlete => countByColor[Color.Blue] == pipeCount
                                        || countByColor[Color.Green] == pipeCount
                                        || countByColor[Color.Red] == pipeCount
                                        || countByColor[Color.Yellow] == pipeCount;

        public GameField(int width = 10, int height = 10)
        {
            StepCount = 0;

            pipeCount = height * width;

            ButtonsField = new Button[width, height];
            PipesField = new Pipe[width, height];
            var rnd = new Random();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    CreatePipe(x, y, rnd);
                }
            }
        }

        private void CreatePipe(int x, int y, Random rnd)
        {
            var mainOutletDirection = (Direction)rnd.Next(4);
            var pipeColor = (Color)rnd.Next(4);
            PipesField[x, y] = new Pipe(mainOutletDirection, pipeColor);
            countByColor[pipeColor]++;

            var size = new Size(50, 50);
            ButtonsField[x, y] = new Button()
            {
                Location = new Point(50 * x, 50 * y),
                Image = PipesField[x, y].PipeImage,
                Size = size
            };

            ButtonsField[x, y].Click += (sender, e) => MakeMove(x, y);
        }

        private void MakeMove(int x, int y)
        {
            StepCount++;
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                var pipe = PipesField[point.X, point.Y];
                pipe.Turn();
                ButtonsField[point.X, point.Y].Image = pipe.PipeImage;
                Thread.Sleep(500);
                AddToQueue(point, pipe.MainOutletDirection, queue);
                AddToQueue(point, pipe.RightOutletDirection, queue);
                if (IsComlete)
                {
                    MessageBox.Show($"Вы победили за {StepCount} шагов", "Победа!", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }

        }

        private void AddToQueue(Point ParentPipeLocation, Direction direction, Queue<Point> queue)
        {
            var pointOfMainOutlet = GetPointAtDirection(direction, ParentPipeLocation);
            if (pointOfMainOutlet.X < 0 || pointOfMainOutlet.X >= PipesField.GetLength(0) || pointOfMainOutlet.Y < 0 ||
                pointOfMainOutlet.Y >= PipesField.GetLength(1)) return;

            var nextPipe = PipesField[pointOfMainOutlet.X, pointOfMainOutlet.Y];
            if (GetPointAtDirection(nextPipe.MainOutletDirection, pointOfMainOutlet) != ParentPipeLocation &&
                GetPointAtDirection(nextPipe.RightOutletDirection, pointOfMainOutlet) != ParentPipeLocation) return;

            queue.Enqueue(pointOfMainOutlet);
            var pipe = PipesField[ParentPipeLocation.X, ParentPipeLocation.Y];
            countByColor[nextPipe.PipeColor]--;
            nextPipe.ChangeColor(pipe.PipeColor);
            countByColor[nextPipe.PipeColor]++;
        }

        private Point GetPointAtDirection(Direction direction, Point Location)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(Location.X, Location.Y - 1);
                case Direction.Down:
                    return new Point(Location.X, Location.Y + 1);
                case Direction.Right:
                    return new Point(Location.X + 1, Location.Y);
                case Direction.Left:
                    return new Point(Location.X - 1, Location.Y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
