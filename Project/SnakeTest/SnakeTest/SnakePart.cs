using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeTest
{
    public class SnakePart 
    {
        private Rectangle part;
        private string lastDirection;
        private string currDirection; 

        public SnakePart(Color color)
        {
            part = new Rectangle();
            part.Stroke = new SolidColorBrush(color);
            part.Fill = new SolidColorBrush(color);
            part.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\snake.jpg", UriKind.Absolute))
            };
            part.StrokeThickness = 2;
            part.Width = 50;
            part.Height = 50;
            currDirection = "right"; 
        }

        public SnakePart(Color color, string h)
        {
            part = new Rectangle();
            //part.Stroke = new SolidColorBrush(color);
            part.Fill = new SolidColorBrush(color);
            part.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\right.jpg", UriKind.Absolute))
            };
            //part.StrokeThickness = 2;
            part.Width = 50;
            part.Height = 50;
            currDirection = "right";
        }

        public Rectangle getPart()
        {
            return part; 
        }

        public void setLastDirection(string ld)
        {
            lastDirection = ld; 
        }

        public string getLastDirection()
        {
            return lastDirection; 
        }

        public void setCurrentDirection(string nd)
        {
            currDirection = nd;
        }

        public string getCurrentDirection()
        {
            return currDirection;
        }
    }
}
