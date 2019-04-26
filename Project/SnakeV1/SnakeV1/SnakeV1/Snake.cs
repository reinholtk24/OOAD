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
        //This is probably the least best designed class in the project.
        //The snake is responsible for updating the location of every SnakePart
        // This class also checks if the snake eats food and needs to grow and appends another Body : SnakePart to the Snake
        // This class also checks for out of bounds collisions 
        // this class also checks for obstacle collisions
        Random rnd = new Random();
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        private List<SnakePart> snake;
        string direction; 
        int speed; 

        public Snake()
        { 
            //initialize the snake with a Head and Body part
            snake = new List<SnakePart>();
            SnakePart s1 = new Head();
            SnakePart s2 = new Body();
            speed = (int)s1.getPart().Width; 
            Canvas.SetLeft(s1.getPart(), 210);
            Canvas.SetTop(s1.getPart(), 100);
            Canvas.SetLeft(s2.getPart(), Canvas.GetLeft(s1.getPart())-speed);
            Canvas.SetTop(s2.getPart(), 100);

            //Add the snake parts to the gameArea
            win.GameCanvas.Children.Add(s1.getPart());
            win.GameCanvas.Children.Add(s2.getPart());

            //Add the snake parts to the list of snake parts that keeps track of each parts information
            snake.Add(s1);
            snake.Add(s2);
        }

        public bool isAlive()
        {
            //This checks to make sure the snake has a head and body parts
            //If the list of snake parts is empty, isAlive() returns false
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
            //Returns true if the snake eats food (collides with the food object) 
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
            //Based on the current direction of the snake, we want to update the graphic for the snake head
            Rectangle h = (Rectangle)win.GameCanvas.Children[0];
            if (direction == "up")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\snakeheadUp.jpg", UriKind.Absolute))
                };
            }
            if (direction == "down")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\snakeheadDown.jpg", UriKind.Absolute))
                };
            }
            if (direction == "left")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\snakeheadLeft.jpg", UriKind.Absolute))
                };
            }
            if (direction == "right")
            {
                h.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\snakehead.jpg", UriKind.Absolute))
                };
            }
        }

        public bool checkCollision()
        {
            //This function checks to see if there is collision with the snake and any of its body parts
            // returns true if there is a collision
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
            //this function returns true if there is a collision with the snake head and an obstacle
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
            //This function adds a new Body part to the snake
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

            sNew.setLastDirection(d);
            win.GameCanvas.Children.Add(sNew.getPart());
            snake.Add(sNew);
        }

        public void resetObstacles()
        {
            //randomly select locations to render the objects to the gameArea
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
            //check location of snake head, if it is out of bounds return true
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
            //used to store current direction for each snake part 
            // this is used to set the next SnakeParts nextDirection
            // if the current snakepart is the Head, the currDirection is set to the user's input direction
            // Then, the list of snakeparts is traversed and all snakepart locations are updated accordingly
            // This function alls checks if the Head of the snakes collides into the edges of the gameArea, the obstacles, or the food. 
            string currDirection = "";
            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    currDirection = direction;
                    //change graphic for the head depending on the direction of the snake
                    changeHead();
                    if (checkCollision())
                    {
                        //gameover
                        win.GameCanvas.Children.Clear();
                        win.gameText.Text = "Game Over";
                        win.gameText.Visibility = System.Windows.Visibility.Visible;
                        win.restart.Visibility = System.Windows.Visibility.Visible;
                        win.easy.Visibility = System.Windows.Visibility.Visible;
                        win.hard.Visibility = System.Windows.Visibility.Visible;
                        win.medium.Visibility = System.Windows.Visibility.Visible;
                        snake.Clear();
                        break;
                    }
                    if (outOfBounds())
                    {
                        //gameover
                        win.GameCanvas.Children.Clear();
                        win.gameText.Text = "Game Over";
                        win.gameText.Visibility = System.Windows.Visibility.Visible;
                        win.restart.Visibility = System.Windows.Visibility.Visible;
                        win.easy.Visibility = System.Windows.Visibility.Visible;
                        win.hard.Visibility = System.Windows.Visibility.Visible;
                        win.medium.Visibility = System.Windows.Visibility.Visible;
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

                //The next 4 boolean clauses render the current the snakepart to its new location
                // and updates the direction of the current part
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
                    //if checkFood returns true, this means the snake has eaten and needs to grow. 
                    
                    //Grab x and y coordinate of the tail of the snake from the canvas
                    double xs = Canvas.GetLeft(snake[snake.Count - 1].getPart());
                    double ys = Canvas.GetTop(snake[snake.Count - 1].getPart());

                    //Grab direction of the tail
                    string d = snake[snake.Count - 1].getCurrentDirection();
                    
                    //Pass this data into addPart so that the snake knows where to render its new tail and the direction
                    //it needs to travel
                    addPart(xs, ys, d);

                    //Update the score
                    win.score.Content = "Score: " + ((snake.Count - 2) * 50).ToString();

                    //after the snake eats we want to reset all of the obstacles. 
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
                        //if checkObstacle is true, that means there was a collision with the snake head and the obstacle
                        //therefore, gameover. 
                        win.GameCanvas.Children.Clear();
                        win.gameText.Text = "Game Over";
                        win.gameText.Visibility = System.Windows.Visibility.Visible;
                        win.restart.Visibility = System.Windows.Visibility.Visible;
                        win.easy.Visibility = System.Windows.Visibility.Visible;
                        win.hard.Visibility = System.Windows.Visibility.Visible;
                        win.medium.Visibility = System.Windows.Visibility.Visible;
                        snake.Clear();
                        break;
                    }
                }
            }
        }

        // this is used to get the rectangle from the canvas associated with the Food object
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
