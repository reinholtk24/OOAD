using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Kyle Reinholt 
 * Course: OOAD 
 * HW1 - Question 4
 * 
*/

namespace Shapes
{
    class ShapeDisplay
    {
        List<Shape> shapes; 

        public ShapeDisplay(List<Shape> shapes)
        {
            this.shapes = shapes; 
        }

        public void displayAll()
        {
            foreach(Shape s in shapes)
            {
                s.display();
                s.displayInfo();
            }
        }
    }
}
