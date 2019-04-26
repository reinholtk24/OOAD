using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SnakeV1
{
    class Food : GamePiece
    {
        public Food() : base() 
        {
            addToCanvas(); 
        }

        public void addToCanvas()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, ((int)win.GameCanvas.Width - (int)part.Width));
            int y = rnd.Next(1, ((int)win.GameCanvas.Height - (int)part.Height));
            Canvas.SetLeft(part, x);
            Canvas.SetTop(part, y);
            Canvas.SetZIndex(part, 3); 
            win.GameCanvas.Children.Add(part); 
        }

        public override void setGraphic()
        {
            graphic = "cricket.jpg";
        }

        public override void setType()
        {
            type = "food";
            part.Name = type;
        }
    }
}
