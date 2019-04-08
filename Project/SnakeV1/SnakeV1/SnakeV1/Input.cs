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

        public string getDirection()
        {
            return direction;
        }

        public virtual void setType()
        {
            inputType = "";
        }

        public void showType()
        {
            Console.WriteLine(inputType); 
        }
    }
}
