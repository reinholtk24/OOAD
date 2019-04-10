using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeV1
{
    class Input
    {
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
