using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes; 

namespace SnakeV1
{
    class SnakePart : GamePiece
    {
        private string lastDirection;
        private string currDirection;

        public SnakePart() : base()
        {
            currDirection = "right"; 
        }

        public Rectangle getPart()
        {
            return part;
        }

        public void setLastDirection(string ld)
        {
            lastDirection = ld;
        }

        public string getLastDirection()
        {
            return lastDirection;
        }

        public void setCurrentDirection(string nd)
        {
            currDirection = nd;
        }

        public string getCurrentDirection()
        {
            return currDirection;
        }
    }
}
