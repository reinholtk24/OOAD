using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shapes
{
    class Circle : Shape
    {
        private int radius;

        public Circle(Point l, int z, int length, string type) : base(l, z, length, type)
        {

        }

        //override dimensions because we want circle to be in terms of a radius rather than side length
        public override void setDimensions(int l)
        {
            radius = l/2; 
        }

        public override int getDimensions()
        {
            return radius;
        }

        public override void display()
        {
            for (int i = 0; i < getLocation().X; i++)
            {
                for (int j = 0; j < getLocation().Y; j++)
                {
                    Console.Write(" "); 
                }
                if(i + 1 == getLocation().X)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine(" ");
                }
            }

            Console.WriteLine("    ***    ");

            for (int k = 0; k < getLocation().Y; k++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("   *    *   ");

            for (int k = 0; k < getLocation().Y; k++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("    ***    "); 
        }

    }
}
