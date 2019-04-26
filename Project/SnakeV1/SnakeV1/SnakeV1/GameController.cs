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
        public Input currentInput;
        Snake snake;
        GamePiece food;
 
        string gameDifficulty;
        public System.Timers.Timer aTimer;

        public GameController()
        {
          
        }

        public void newGame()
        {
            currentInput = new Keyboard();
            snake = new Snake();
            food = new Food();
           
            if(gameDifficulty == "easy")
            {
                addObstacles(5);
            }
            else if (gameDifficulty == "medium")
            {
                addObstacles(10);
            }
            else if(gameDifficulty == "hard")
            {
                addObstacles(20);
            }
            
        }

        private void addObstacles(int count)
        {
           
            for (int i = 0; i < count; i++)
            {
                Obstacle obstacle = new Obstacle();
            }
            
       
        }

        public string getLevel()
        {
            return gameDifficulty;
        }

        public void setLevel(string difficulty)
        {
            this.gameDifficulty = difficulty;
        }

        public void setInputAsTouch()
        {
            if (currentInput.getType() == "gaze")
            {
                currentInput.hide();
            }
            currentInput = new Touch();
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

        public void setInputAsSpeech()
        {
            if (currentInput.getType() == "gaze")
            {
                currentInput.hide();
            }
            currentInput = new Speech();
        }

        private int getSpeed(string difficulty)
        {
            int refreshRate = 1000; 
            if(difficulty == "easy")
            {
                refreshRate = 160;
            }
            else if (difficulty == "medium")
            {
                refreshRate = 140;
            }
            else if (difficulty == "hard")
            {
                refreshRate = 60;
            }

            return refreshRate; 

        }

        public void SetTimer(string difficulty)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(getSpeed(difficulty)); // put in a smaller value to make the snake faster
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
                if (snake.isAlive())
                {
                    snake.moveSnake2();
                }
                else
                {
                    aTimer.Stop();
                    aTimer.Dispose(); 
                    
                }
            });
        }

        


    }
}
