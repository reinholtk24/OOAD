﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace SnakeV1
{
    class GameController
    {
        Input currentInput;
        Snake snake;
        public System.Timers.Timer aTimer;

        public GameController()
        {
            currentInput = new Keyboard();
            snake = new Snake();
            SetTimer(); 
        }

        public void setInputAsKeyboard()
        {
            if(currentInput.getType() == "gaze")
            {
                currentInput.hide(); 
            }
            currentInput = new Keyboard(); 
        }

        public void setInputAsMouse()
        {
            if (currentInput.getType() == "gaze")
            {
                currentInput.hide();
            }
            currentInput = new Mouse(); 
        }

        public void setInputAsGaze()
        {
            currentInput = new Gaze(); 
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(500); // put in a smaller value to make the snake faster
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
            snake.setDirection(currentInput.getDirection());
            Application.Current.Dispatcher.Invoke(() =>
            {
                snake.moveSnake();
            });
        }


    }
}
