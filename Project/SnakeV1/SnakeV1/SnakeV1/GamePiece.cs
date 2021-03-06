﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeV1
{
    class GamePiece
    {
        //Food, Obstacle, and SnakePart all inherit from this class
        //This class allows for each gamepiece to setgraphics and type for each gamepiece in the canvas
        protected MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow; 
        protected Rectangle part;
        protected string type;
        protected string graphic; 

        public GamePiece()
        {
            setGraphic();
            loadGraphic();
            setType();
        }

        public virtual void setGraphic()
        {
            graphic = "snake.jpg"; 
        }

        public void loadGraphic()
        {
            Color color = Colors.Black; 
            part = new Rectangle();
            part.Stroke = new SolidColorBrush(color);
            part.Fill = new SolidColorBrush(color);
            part.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\"+graphic, UriKind.Absolute))
            };
            part.StrokeThickness = 2;
            part.Width = 25;
            part.Height = 25; 
        }

        public virtual void setType()
        {
            type = ""; 
        }

        public string getType()
        {
            return type; 
        }

    }
}
