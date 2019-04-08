using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeV1
{
    class Body : SnakePart
    {
        public Body() : base() 
        {

        }

        public override void setGraphic()
        {
            graphic = "snake.jpg";
        }

        public override void setType()
        {
            type = "snake";
            part.Name = type; 
        }
    }
}
