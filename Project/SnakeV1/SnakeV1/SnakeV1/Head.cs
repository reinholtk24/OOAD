using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeV1
{
    class Head : SnakePart
    {
        public Head() : base() 
        {

        }

        public override void setGraphic()
        {
            graphic = "right.jpg"; 
        }

        public override void setType()
        {
            type = "snake";
            part.Name = type; 
        }
    }
}
