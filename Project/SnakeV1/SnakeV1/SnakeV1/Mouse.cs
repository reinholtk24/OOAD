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
        int startSwipe = -1;
        Point start; 

        public Mouse() : base()
        {
            //Add a mouseMove event to the canvas 
            win.GameCanvas.MouseMove += GameCanvas_MouseMove;
            start = new Point(); 
        }

        public bool timeDifference(int start, int end)
        {
            //We check the time difference here because we only want to detect long swipe gestures 
            // not quick sparatic movements with the mouse
            bool flag = false;
            int dif = (end - start);
            
            if(dif > 90 )
            {
                flag = true; 
            }

            return flag; 
        }

        public bool squareDistance(double x1, double x2, double y1, double y2)
        {
            //get distance between 2 points and make sure the distance is at least 30 pixels 
            // return true when the square distance is greater than 30 
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
            //when the mouse is move event is triggered, we want to check the distance between the start of the gesture
            // and the end of the gesture, we also check the time to make sure the gesture was intentional. 
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

                    //check square distance between startSwipe point and current end point of mouse
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

                }

                
            }
                
        }

        public override void setType()
        {
            inputType = "mouse";
        }
    }
}
