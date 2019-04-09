using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeV1
{
    class Mouse : Input
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        int startSwipe = -1;
        Point start; 

        public Mouse() : base()
        {
            win.GameCanvas.MouseMove += GameCanvas_MouseMove;
            start = new Point(); 
        }

        public bool timeDifference(int start, int end)
        {
            bool flag = false;
            int dif = (end - start);
            //Console.WriteLine("time difference: " + dif.ToString()); 
            if(dif > 90 )
            {
                flag = true; 
            }

            return flag; 
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
             
            if(dif > 30)
            {
                flag = true; 
            }

            return flag; 
        }

        private void GameCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (startSwipe == -1)
            {
                startSwipe = e.Timestamp;
                start = new Point(); 
                start =  e.GetPosition(sender as IInputElement);
            }
            else
            {
                if(timeDifference(startSwipe,e.Timestamp))
                {
                    Point current = e.GetPosition(sender as IInputElement);
                    //Console.WriteLine("current: " + current.ToString());
                    //Console.WriteLine("start: " + start.ToString());
                    //Console.WriteLine("swipeStart: " + startSwipe.ToString()); 

                    if (squareDistance(current.X,start.X,current.Y,start.Y))
                    {
                        if (Math.Abs(current.X-start.X) < 50 && current.Y > start.Y)
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

                        startSwipe = -1;
                    }

                    //startSwipe = -1;
                }

                
            }
                
        }

        public override void setType()
        {
            inputType = "mouse";
        }
    }
}
