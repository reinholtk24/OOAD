using System;
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
        GamePiece food;
        GamePiece obs1;
        GamePiece obs2;
        GamePiece obs3;
        public System.Timers.Timer aTimer;

        public GameController()
        {
          
        }

        public void newGame()
        {
            currentInput = new Speech();
            snake = new Snake();
            food = new Food();
            addObstacles(20);
        }

        private void addObstacles(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Obstacle obstacle = new Obstacle(); 
            }
       
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
