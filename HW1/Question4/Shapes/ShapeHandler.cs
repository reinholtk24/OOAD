using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/* Author: Kyle Reinholt 
 * Course: OOAD 
 * HW1 - Question 4
 * 
*/

namespace Shapes
{
    class ShapeHandler
    {
        List<Shape> shapes;
        List<Shape> sortedShapes;

        public ShapeHandler(List<queryRow> list)
        {
            shapes = new List<Shape>(); 

            //This is where object that inherit from the super class shape are instantiated 
            //A little polymorphism
            foreach( queryRow q in list)
            {
                switch(q.shape)
                {
                    case "square":
                        Shape s = new Square(new Point(q.x, q.y), q.z, q.length, "square");
                        shapes.Add(s); 
                        break;
                    case "circle":
                        Shape c = new Circle(new Point(q.x, q.y), q.z, q.length, "circle");
                        shapes.Add(c);
                        break;
                    case "triangle":
                        Shape t = new Triangle(new Point(q.x, q.y), q.z, q.length, "triangle");
                        shapes.Add(t);
                        break;
                    default:
                        break;     
                }
            }
        }

        public List<Shape> sortShapes()
        {
            sortedShapes = shapes.OrderBy(o => o.getZ()).ToList();

            return sortedShapes; 
        }
    }
}
