using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 

namespace Shapes
{
    public class Shape
    {
        private Point Location; // Point is a built-in windows class that contains an X and Y coordinate among other things
        private int length;
        private int z;
        private string type; 

        public Shape(Point l, int z, int length, string type)
        {
            init(l, z, length, type);
        }
        
        //The purpose of the init function is for derived classes (square,circle,triangle, etc.) to utilize the constructor
        public void init(Point l, int z, int length, string type)
        {
            setLocation(l,z);
            setDimensions(length);
            this.type = type; 
        }

        public void setLocation(Point l, int z)
        {
            Location = new Point(l.X, l.Y);
            this.z = z; 
        }

        public int getZ()
        {
            return z; 
        }

        public Point getLocation()
        {
            return Location;
        }

        public virtual int getDimensions()
        {
            return length; 
        }

        public virtual void setDimensions(int length)
        {
            this.length = length; 
        }

        public virtual void display()
        {

        }

        public void displayInfo()
        {
            Console.WriteLine("(X,Y)= " + Location.ToString() + "  z= " + z.ToString() + " type: " + type); 
        }
        
    }


}
