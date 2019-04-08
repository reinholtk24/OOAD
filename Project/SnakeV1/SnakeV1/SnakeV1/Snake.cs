using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace SnakeV1
{
    class Snake
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        private List<SnakePart> snake;
        string direction; 
        int speed; 

        public Snake()
        {
            speed = 50; 
            snake = new List<SnakePart>();
            SnakePart s1 = new Head();
            SnakePart s2 = new Body();
            Canvas.SetLeft(s1.getPart(), 210);
            Canvas.SetTop(s1.getPart(), 100);
            Canvas.SetLeft(s2.getPart(), 160);
            Canvas.SetTop(s2.getPart(), 100);
            win.GameCanvas.Children.Add(s1.getPart());
            win.GameCanvas.Children.Add(s2.getPart());
            snake.Add(s1);
            snake.Add(s2);
        }

        public void setDirection(string direction)
        {
            this.direction = direction; 
        }

        public void changeHead()
        {
            Rectangle h = (Rectangle)win.GameCanvas.Children[0];
            if (direction == "up")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\up.jpg", UriKind.Absolute))
                };
            }
            if (direction == "down")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\down.jpg", UriKind.Absolute))
                };
            }
            if (direction == "left")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\left.jpg", UriKind.Absolute))
                };
            }
            if (direction == "right")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\right.jpg", UriKind.Absolute))
                };
            }
        }

        public bool checkCollision()
        {
            bool flag = false;
            Rectangle head = (Rectangle)win.GameCanvas.Children[0];
            double x = Canvas.GetLeft(head);
            double y = Canvas.GetTop(head);
            for (int i = 1; i < win.GameCanvas.Children.Count; i++)
            {
                var curr = win.GameCanvas.Children[i];
                double compX = Canvas.GetLeft(curr);
                double compY = Canvas.GetTop(curr);
                if (x == compX && y == compY)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public bool outOfBounds()
        {
            bool flag = false;
            var head = win.GameCanvas.Children[0];
            double x = Canvas.GetLeft(head);
            double y = Canvas.GetTop(head);

            double width = win.GameCanvas.Width;
            double height = win.GameCanvas.Height;
            if (x <= 20 || x >= width - 20)
            {
                flag = true;
            }
            else if (y <= 20 || y >= height)
            {
                flag = true;
            }

            return flag;
        }

        public void moveSnake()
        {
            string currDirection = "";

            int index = 0;
            for (int i = 0; i < win.GameCanvas.Children.Count; i++)
            {
                if (i == 0)
                {
                    currDirection = direction;
                    changeHead();
                    if (checkCollision())
                    {
                        win.GameCanvas.Children.Clear();
                        //game.Background = @"C:\\Users\\kychill\\Pictures\\Camera Roll\\go.png";
                        win.GameCanvas.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\go.png", UriKind.Absolute))
                        };
                        snake.Clear();
                        break;
                    }
                    if (outOfBounds())
                    {
                        win.GameCanvas.Children.Clear();
                        win.GameCanvas.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\go.png", UriKind.Absolute))
                        };
                        snake.Clear();
                        break;
                    }
                }
                else
                {
                    currDirection = snake[i - 1].getLastDirection();
                }
                Rectangle currPart = (Rectangle)win.GameCanvas.Children[i];
                if (1 == 1)
                {
                    //Console.WriteLine(Snake.Count);
                    //Console.WriteLine(game.Children.Count);
                    if (snake == null)
                    {
                        break;
                    }
                    SnakePart s = snake[index];
                    s.setLastDirection(s.getCurrentDirection());

                    double x = Canvas.GetLeft(currPart);
                    double y = Canvas.GetTop(currPart);

                    if (currDirection == "right")
                    {
                        Canvas.SetLeft(currPart, x + speed);
                        Canvas.SetTop(currPart, y);
                        s.setCurrentDirection("right");
                    }
                    else if (currDirection == "down")
                    {
                        Canvas.SetLeft(currPart, x);
                        Canvas.SetTop(currPart, y + speed);
                        s.setCurrentDirection("down");
                    }
                    else if (currDirection == "up")
                    {
                        Canvas.SetLeft(currPart, x);
                        Canvas.SetTop(currPart, y - speed);
                        s.setCurrentDirection("up");

                    }
                    else if (currDirection == "left")
                    {
                        Canvas.SetLeft(currPart, x - speed);
                        Canvas.SetTop(currPart, y);
                        s.setCurrentDirection("left");
                    }
                   
                }
                index++;
            }
        }

    }
}
