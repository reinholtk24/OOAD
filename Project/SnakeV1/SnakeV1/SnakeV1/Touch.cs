using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SnakeV1
{
    class Touch : Input
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        Point start; 

        public Touch()
        {
            win.GameCanvas.TouchDown += GameCanvas_TouchDown;
            win.GameCanvas.TouchUp += GameCanvas_TouchUp;
            start = new Point(); 
        }

        public bool squareDistance(double x1, double x2, double y1, double y2)
        {
            bool flag = false;
            double xDif = (x1 - x2);
            double yDif = (y1 - y2);
            double xSqrd = Math.Pow(xDif, 2);
            double ySqrd = Math.Pow(yDif, 2);
            double sum = xSqrd + ySqrd;
            double dif = Math.Sqrt(sum);

            if (dif > 30)
            {
                flag = true;
            }

            return flag;
        }

        private void GameCanvas_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Point current = e.GetTouchPoint(sender as IInputElement).Position; 

            if (squareDistance(current.X, start.X, current.Y, start.Y))
            {
                if (Math.Abs(current.X - start.X) < 50 && current.Y > start.Y)
                {
                    direction = "down";
                }
                else if (Math.Abs(current.X - start.X) < 50 && current.Y < start.Y)
                {
                    direction = "up";
                }
                else if (Math.Abs(current.Y - start.Y) < 50 && current.X < start.X)
                {
                    direction = "left";
                }
                else if (Math.Abs(current.Y - start.Y) < 50 && current.X > start.X)
                {
                    direction = "right";
                }

            }
        }

        private void GameCanvas_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            start = e.GetTouchPoint(sender as IInputElement).Position;
        }

       
        
    }
}
