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
        Random rnd = new Random();
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

        public bool isAlive()
        {
            bool flag = true; 
            if(snake.Count > 0)
            {
                flag = true; 
            }
            else
            {
                flag = false; 
            }

            return flag; 
        }

        public void setDirection(string direction)
        {
            this.direction = direction; 
        }

        public bool checkFood(Rectangle f)
        {
            bool flag = false;
            Rectangle head = (Rectangle)win.GameCanvas.Children[0];
            double left = (Canvas.GetLeft(head));
            double top = (Canvas.GetTop(head));
            if (left >= (Canvas.GetLeft(f) - speed) && left <= (Canvas.GetLeft(f) + speed))
            {
                if (top >= (Canvas.GetTop(f) - speed) && top <= (Canvas.GetTop(f) + speed))
                {
                    int x = rnd.Next(1, ((int)win.GameCanvas.Width - (int)f.Width));
                    int y = rnd.Next(1, ((int)win.GameCanvas.Height - (int)f.Height));
                    Canvas.SetLeft(f, x);
                    Canvas.SetTop(f, y);
                    flag = true;
                }
            }
            return flag;
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

        public bool checkObstacle(Rectangle f)
        {
            bool flag = false;
           
            Rectangle head = (Rectangle)win.GameCanvas.Children[0];
            double left = (Canvas.GetLeft(head));
            double top = (Canvas.GetTop(head));
            if (left >= (Canvas.GetLeft(f) - speed) && left <= (Canvas.GetLeft(f) + speed))
            {
                if (top >= (Canvas.GetTop(f) - speed) && top <= (Canvas.GetTop(f) + speed))
                {
                    int x = rnd.Next(1, ((int)win.GameCanvas.Width - (int)f.Width));
                    int y = rnd.Next(1, ((int)win.GameCanvas.Height - (int)f.Height));
                    Canvas.SetLeft(f, x);
                    Canvas.SetTop(f, y);
                    flag = true;
                }
            }
            return flag;
        }

        public void addPart(double x, double y, string d)
        {
            SnakePart sNew = new Body();

            if (d == "right")
            {
                Canvas.SetLeft(sNew.getPart(), x - speed);
                Canvas.SetTop(sNew.getPart(), y);
            }
            else if (d == "left")
            {
                Canvas.SetLeft(sNew.getPart(), x + speed);
                Canvas.SetTop(sNew.getPart(), y);
            }
            else if (d == "up")
            {
                Canvas.SetLeft(sNew.getPart(), x);
                Canvas.SetTop(sNew.getPart(), y + speed);
            }
            else if (d == "down")
            {
                Canvas.SetLeft(sNew.getPart(), x);
                Canvas.SetTop(sNew.getPart(), y - speed);
            }
            //sNew.setCurrentDirection(d);
            sNew.setLastDirection(d);
            //Rectangle f = (Rectangle)win.GameCanvas.Children[win.GameCanvas.Children.Count - 1];
            //win.GameCanvas.Children.RemoveAt(win.GameCanvas.Children.Count - 1);
            win.GameCanvas.Children.Add(sNew.getPart());
            //win.GameCanvas.Children.Add(f);
            snake.Add(sNew);
        }

        public void resetObstacles()
        {
            for (int i = 0; i < win.GameCanvas.Children.Count; i++)
            {
                Rectangle currPart = (Rectangle)win.GameCanvas.Children[i];
                if (currPart.Name == "obstacle")
                {
                    int x = rnd.Next(1, ((int)win.GameCanvas.Width - (int)currPart.Width));
                    int y = rnd.Next(1, ((int)win.GameCanvas.Height - (int)currPart.Height));
                    Canvas.SetLeft(currPart, x);
                    Canvas.SetTop(currPart, y);
                }
            }
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

        public void moveSnake2()
        {
            string currDirection = "";
            for (int i = 0; i < snake.Count; i++)
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
                Rectangle currPart = snake[i].getPart();
                if (snake == null)
                {
                    break;
                }
                SnakePart s = snake[i];
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
            if (snake.Count > 0)
            {
                Rectangle f = getChild("food");
                if (checkFood(f))
                {
                    double xs = Canvas.GetLeft(snake[snake.Count - 1].getPart());
                    double ys = Canvas.GetTop(snake[snake.Count - 1].getPart());
                    string d = snake[snake.Count - 1].getCurrentDirection();
                    addPart(xs, ys, d);
                    win.score.Content = "Score: " + ((snake.Count - 2) * 50).ToString();
                    resetObstacles();
                }
                checkAllObstacles();
            }
        }

        public void checkAllObstacles()
        {
            for (int i = 0; i < win.GameCanvas.Children.Count; i++)
            {
                Rectangle o = (Rectangle)win.GameCanvas.Children[i];
                if (o.Name == "obstacle")
                {
                    if (checkObstacle(o))
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
            }
        }

        public Rectangle getChild(string name)
        {
            Rectangle child = new Rectangle(); 
            for(int i = 0; i < win.GameCanvas.Children.Count; i++)
            {
                Rectangle gp = (Rectangle)win.GameCanvas.Children[i];
                if (gp.Name == "food")
                {
                    child = gp; 
                }
            }
            return child; 
        }
    }
}
