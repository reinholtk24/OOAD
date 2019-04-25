using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeV1
{
    class Obstacle : GamePiece
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Obstacle() : base() { addToCanvas(); }
        public override void setType()
        {
            type = "obstacle";
            part.Name = type; 
        }

        public override void setGraphic()
        {
            graphic = "obs.jpg"; 
        }

        public void addToCanvas()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, ((int)win.GameCanvas.Width-(int)part.Width));
            int y = rnd.Next(1, ((int)win.GameCanvas.Height-(int)part.Height));
            Canvas.SetLeft(part, -100);
            Canvas.SetTop(part, -100);
            win.GameCanvas.Children.Add(part);
        }
    }
}
