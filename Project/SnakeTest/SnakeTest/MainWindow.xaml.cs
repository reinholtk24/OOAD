using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace SnakeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public System.Timers.Timer aTimer;
        int speed = 50;
        public static string direction = "right";
        public static string ls = "right";
        public static Rectangle food;
        public static int runningScore =0; 

        public static List<SnakePart> Snake;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void setFood(Color color)
        {
            food = new Rectangle();
            food.Stroke = new SolidColorBrush(color);
            food.Fill = new SolidColorBrush(color);
            food.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\food2.jpg", UriKind.Absolute))
            };
            food.StrokeThickness = 2;
            food.Width = 50;
            food.Height = 50;
            food.Name = "food";
            Random rnd = new Random();
            int x = rnd.Next(1, 400);
            int y = rnd.Next(1, 400);
            Canvas.SetLeft(food, x);
            Canvas.SetTop(food, y);
            game.Children.Add(food);
        }

        public void loadSnake()
        {
            SnakePart s1 = new SnakePart(Colors.Aqua,"head");
            SnakePart s2 = new SnakePart(Colors.Black);
            //SnakePart s3 = new SnakePart(Colors.Black);
            //SnakePart s4 = new SnakePart(Colors.Black);
            //SnakePart s5 = new SnakePart(Colors.Black);
            Canvas.SetLeft(s1.getPart(), 210);
            Canvas.SetTop(s1.getPart(), 100);
            Canvas.SetLeft(s2.getPart(), 160);
            Canvas.SetTop(s2.getPart(), 100);
            //Canvas.SetLeft(s3.getPart(), 100);
            //Canvas.SetTop(s3.getPart(), 100);
            //Canvas.SetLeft(s4.getPart(), 40);
            //Canvas.SetTop(s4.getPart(), 100);
            //Canvas.SetLeft(s5.getPart(), -20);
            //Canvas.SetTop(s5.getPart(), 100);
            game.Children.Add(s1.getPart());
            game.Children.Add(s2.getPart());
            //game.Children.Add(s3.getPart());
            //game.Children.Add(s4.getPart());
            //game.Children.Add(s5.getPart());
            Snake.Add(s1);
            Snake.Add(s2);
            //Snake.Add(s3);
            //Snake.Add(s4);
            //Snake.Add(s5);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(180); // put in a smaller value to make the snake faster
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
            this.Dispatcher.Invoke(() =>
            {
                moveSnake();
            });

        }

        public void addPart(double x, double y, string d)
        {
            SnakePart sNew = new SnakePart(Colors.Black);


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
            Rectangle f = (Rectangle)game.Children[game.Children.Count - 1];
            game.Children.RemoveAt(game.Children.Count - 1);
            game.Children.Add(sNew.getPart());
            game.Children.Add(f);
            Snake.Add(sNew);
        }

        public bool checkFood(Rectangle f)
        {
            bool flag = false;
            Rectangle head = (Rectangle)game.Children[0];
            double left = (Canvas.GetLeft(head));
            double top = (Canvas.GetTop(head));
            if (left >= (Canvas.GetLeft(f) - speed) && left <= (Canvas.GetLeft(f) + speed))
            {
                if (top >= (Canvas.GetTop(f) - speed) && top <= (Canvas.GetTop(f) + speed))
                {
                    Random rnd = new Random();
                    int x = rnd.Next(1, 400);
                    int y = rnd.Next(1, 400);
                    Canvas.SetLeft(f, x);
                    Canvas.SetTop(f, y);
                    flag = true;
                }
            }
            return flag;
        }

        public bool checkCollision()
        {
            bool flag = false;
            Rectangle head = (Rectangle)game.Children[0];
            double x = Canvas.GetLeft(head);
            double y = Canvas.GetTop(head);
            for (int i = 1; i < game.Children.Count; i++)
            {
                var curr = game.Children[i];
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
            var head = game.Children[0];
            double x = Canvas.GetLeft(head);
            double y = Canvas.GetTop(head);

            double width = game.Width;
            double height = game.Height;
            if (x <= 20 || x >= width-20)
            {
                flag = true; 
            }
            else if( y <= 20 || y >= height)
            {
                flag = true; 
            }

            return flag; 
        }

        public void changeHead()
        {
            Rectangle h =  (Rectangle)game.Children[0];
            if(direction == "up")
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

        public void moveSnake()
        {
            string currDirection = "";

            int index = 0; 
            for(int i = 0; i <  game.Children.Count; i++)
            {
                if(i == 0)
                {
                    currDirection = direction;
                    changeHead(); 
                    if(checkCollision())
                    {
                        start.Visibility = Visibility.Visible;
                        game.Children.Clear();
                        //game.Background = @"C:\\Users\\kychill\\Pictures\\Camera Roll\\go.png";
                        game.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\go.png", UriKind.Absolute))
                        };
                        Snake.Clear();
                        break;
                    }
                    if(outOfBounds())
                    {
                        start.Visibility = Visibility.Visible;
                        game.Children.Clear();
                        game.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\go.png", UriKind.Absolute))
                        };
                        Snake.Clear();
                        break;
                    }
                }
                else
                { 
                    currDirection = Snake[i - 1].getLastDirection();
                }
                Rectangle currPart = (Rectangle)game.Children[i];
                if (currPart.Name == "food")
                {
                    if (checkFood(currPart))
                    {
                        double xs = Canvas.GetLeft((Rectangle)game.Children[i - 1]);
                        double ys = Canvas.GetTop((Rectangle)game.Children[i - 1]);
                        string d = Snake[i - 1].getCurrentDirection();
                        addPart(xs, ys, d);
                        runningScore+=50;
                        score.Content = "Score: " + runningScore.ToString();
                        index = index - 1;
                        break;
                    }
                }
                else
                {
                    //Console.WriteLine(Snake.Count);
                    //Console.WriteLine(game.Children.Count);
                    if(Snake == null)
                    {
                        break;
                    }
                    SnakePart s = Snake[index];
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                direction = "down"; 
                
            }
            else if (e.Key == Key.Up)
            {
                direction = "up";
            }
            else if (e.Key == Key.Left)
            {
                direction = "left";
            }
            else if (e.Key == Key.Right)
            {
                direction = "right";
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            direction = "right";
            runningScore = 0; 
            if(aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose(); 
            }
            if (Snake == null)
            {
                Snake = new List<SnakePart>();
            }
            loadSnake();
            SetTimer();
            setFood(Colors.Black);
            score.Content = "Score: 0";
            start.Visibility = Visibility.Hidden;
            game.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\paradise.jpg", UriKind.Absolute))
            };
        }
    }
}
