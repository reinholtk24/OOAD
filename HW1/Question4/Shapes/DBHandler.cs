using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class DBHandler
    {
        List<queryRow> Query; 

        public void connectToDB(string DBName)
        {
            Console.WriteLine("Connection to " + DBName.ToString() + " successful."); 
        }

        //Creates a fake db query, note the fourth parameter is z-order and it is not in the correct order yet. 
        public List<queryRow> selectStatement(string query)
        {
            Query = new List<queryRow>();
                           //queryRow(x, y, length, z-order, shape-type)
            queryRow q1 = new queryRow(2,2,5,0,"circle");
            queryRow q2 = new queryRow(4, 4, 5, 1, "circle");
            queryRow q3 = new queryRow(2, 2, 10, 2, "square");
            queryRow q4 = new queryRow(5, 5, 5, 0, "triangle");
            queryRow q5 = new queryRow(2, 2, 10, 1, "circle");
            queryRow q6 = new queryRow(6, 6, 15, 2, "triangle");
            queryRow q7 = new queryRow(2, 2, 5, 0, "circle");
            queryRow q8 = new queryRow(7, 7, 5, 1, "square");
            queryRow q9 = new queryRow(2, 2, 5, 2, "square");

            Query.Add(q1);
            Query.Add(q2);
            Query.Add(q3);
            Query.Add(q4);
            Query.Add(q5);
            Query.Add(q6);
            Query.Add(q7);
            Query.Add(q8);
            Query.Add(q9);

            return Query; 

        }

    }

    struct queryRow
    {
        public int x;
        public int y;
        public int length;
        public int z;
        public string shape; 

        public queryRow(int x, int y, int length, int z, string shape)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.z = z;
            this.shape = shape; 
        }
    }
}
