using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class Images
    {
        public Dictionary<Color, Dictionary<Direction, Image>> PipeImages;

        public Images()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            PipeImages = new Dictionary<Color, Dictionary<Direction, Image>>();
            var yellowPipes =
                new Dictionary<Direction, Image>
                {
                    [Direction.Up] = Image.FromFile($@"{dir}\Images\Yellow\Up.png"),
                    [Direction.Right] = Image.FromFile($@"{dir}\Images\Yellow\Right.png"),
                    [Direction.Down] = Image.FromFile($@"{dir}\Images\Yellow\Down.png"),
                    [Direction.Left] = Image.FromFile($@"{dir}\Images\Yellow\Left.png")
                };

            var greenPipes =
                new Dictionary<Direction, Image>
                {
                    [Direction.Up] = Image.FromFile($@"{dir}\Images\Green\Up.png"),
                    [Direction.Right] = Image.FromFile($@"{dir}\Images\Green\Right.png"),
                    [Direction.Down] = Image.FromFile($@"{dir}\Images\Green\Down.png"),
                    [Direction.Left] = Image.FromFile($@"{dir}\Images\Green\Left.png")
                };

            var redPipes =
                new Dictionary<Direction, Image>
                {
                    [Direction.Up] = Image.FromFile($@"{dir}\Images\Red\Up.png"),
                    [Direction.Right] = Image.FromFile($@"{dir}\Images\Red\Right.png"),
                    [Direction.Down] = Image.FromFile($@"{dir}\Images\Red\Down.png"),
                    [Direction.Left] = Image.FromFile($@"{dir}\Images\Red\Left.png")
                };

            var bluePipes =
                new Dictionary<Direction, Image>
                {
                    [Direction.Up] = Image.FromFile($@"{dir}\Images\Blue\Up.png"),
                    [Direction.Right] = Image.FromFile($@"{dir}\Images\Blue\Right.png"),
                    [Direction.Down] = Image.FromFile($@"{dir}\Images\Blue\Down.png"),
                    [Direction.Left] = Image.FromFile($@"{dir}\Images\Blue\Left.png")
                };

            PipeImages[Color.Yellow] = yellowPipes;
            PipeImages[Color.Green] = greenPipes;
            PipeImages[Color.Red] = redPipes;
            PipeImages[Color.Blue] = bluePipes;
        }
    }
}
