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
    class Triangle : Shape
    {
        public Triangle(Point l, int z, int length, string type) : base(l, z, length, type)
        {

        }

        public override void display()
        {
            for (int i = 0; i < getLocation().X; i++)
            {
                for (int j = 0; j < getLocation().Y; j++)
                { 
                     Console.Write(" ");
                }
                if (i + 1 == getLocation().X)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                }
            }

            Console.WriteLine("     *     ");
            for (int k = 0; k < getLocation().Y; k++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("    * *    ");

            for (int k = 0; k < getLocation().Y; k++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("   * * *   ");

            for (int k = 0; k < getLocation().Y; k++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  * * * *  ");
        } 
    }
}
