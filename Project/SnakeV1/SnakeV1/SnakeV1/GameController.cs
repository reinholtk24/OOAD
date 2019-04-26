using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SnakeV1
{
    class GameController
    {
        Input currentInput;
        Snake snake;
        GamePiece food;

        string gameDifficulty;
        public System.Timers.Timer aTimer;
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public GameController()
        {
            //When this object is instantiated, we want a null pointer to the object space in memory
            //when new game is called, we can instantiate the currentInput, snake, food, background, and obstacle objects
        }

        public void newGame()
        {
            currentInput = new Keyboard();
            snake = new Snake();
            food = new Food();
            win.GameCanvas.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\grass1.jpg", UriKind.Absolute))
            };

            if (gameDifficulty == "easy")
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

        public void setInputAsKeyboard()
        {
            if(currentInput.getType() == "gaze")
            {
                currentInput.hide(); 
            }
            currentInput = new Keyboard(); 
        }

        public void setInputAsTouch()
        {
            if (currentInput.getType() == "gaze")
            {
                currentInput.hide();
            }
            currentInput = new Touch();
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
            // put in a smaller value to make the snake faster
            aTimer = new System.Timers.Timer(getSpeed(difficulty)); 
            
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //When the timers interval has elapsed, we invoke a thread to move the snake

            //based on the current input, get the most current direction input by the user and set the 
            // snakes direction
            snake.setDirection(currentInput.getDirection());
            Application.Current.Dispatcher.Invoke(() =>
            {
                //Then, if the snake is alive, move the snake
                if (snake.isAlive())
                {
                    snake.moveSnake2();
                }
                else
                {
                    //else, the snake is dead and we can stop the timer
                    aTimer.Stop();
                    aTimer.Dispose(); 
                    
                }
            });
        }

        


    }
}
