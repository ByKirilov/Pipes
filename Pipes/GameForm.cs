using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Pipes
{
    class GameForm : Form
    {
        public GameForm()
        {
            var gameField = new GameField();

            var lable = new Label()
                        {
                            Location = new Point((gameField.ButtonsField.GetLength(0) + 1) * 50, 0),
                            Size = new Size(200, (gameField.ButtonsField.GetLength(1) + 1) * 50),
                            Font = new Font("Arial", 20),
                            ForeColor = System.Drawing.Color.Black,
                            Text = $@"Количество шагов: {gameField.StepCount}"
                
                        };
            Controls.Add(lable);

            foreach (var button in gameField.ButtonsField)
            {
                button.Click += (sender, args) => lable.Text = $@"Количество шагов: {gameField.StepCount}";
                Controls.Add(button);
            }
            
            var width = (gameField.ButtonsField.GetLength(0) + 1) * 50 + lable.Size.Width;
            var height = lable.Size.Height;

            Size = new Size(width, height);
        }
    }
}
