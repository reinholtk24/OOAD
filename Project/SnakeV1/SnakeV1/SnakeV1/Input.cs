using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeV1
{
    class Input
    {
        //Base class for all inputs: Speech, Touch, Keyboard, Mouse, Gaze
        protected MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        protected string inputType;
        protected string direction; 

        public Input()
        {
            direction = "right"; 
            setType(); 
        }

        public virtual void hide()
        {

        }

        public string getDirection()
        {
            return direction;
        }

        public virtual void setType()
        {
            inputType = "";
        }

        public string getType()
        {
            return inputType;
        }

        public void showType()
        {
            Console.WriteLine(inputType); 
        }
    }
}
