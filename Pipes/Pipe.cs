using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Pipes
{
    class Pipe
    {
        public Direction MainOutletDirection { get; set; }
        public Direction RightOutletDirection { get; set; }
        
        public Color PipeColor { get; set; }

        public Image PipeImage { get; set; }

        private Images images;

        public Pipe(Direction mainOutletDirection, Color pipeColor)
        {
            MainOutletDirection = mainOutletDirection;
            RightOutletDirection = (Direction)(((int)MainOutletDirection + 1) % 4);

            PipeColor = pipeColor;

            images = new Images();

            SetImage();
        }

        private void SetImage()
        {
            PipeImage = images.PipeImages[PipeColor][MainOutletDirection];
            //Thread.Sleep(100);
        }

        public void Turn()
        {
            MainOutletDirection = RightOutletDirection;
            RightOutletDirection = (Direction)(((int)RightOutletDirection + 1) % 4);
            SetImage();
        }

        public void ChangeColor(Color color)
        {
            PipeColor = color;
            SetImage();
        }
    }
}
