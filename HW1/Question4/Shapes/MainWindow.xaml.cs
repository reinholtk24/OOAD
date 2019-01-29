using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //This sets Console output to the textbox in the MainWindow rather than the debug console
            Console.SetOut(new ControlWriter(textbox1));

            string databaseName = "Shapes.db";
            
            //Instantiate database handler object and connect to db 
            DBHandler dBHandler = new DBHandler();
            dBHandler.connectToDB(databaseName);
            
            //run a query to get all of the info we need. 
            List<queryRow> shapeQuery = dBHandler.selectStatement("SELECT * FROM shapes;");
            
            //shape handler turns the query into a list of shape objects such that circle, square, and triangle inherit properties from the shape class
            ShapeHandler shapeHandler = new ShapeHandler(shapeQuery);

            //sort the shapes using z-order
            List<Shape> sortedShapes = shapeHandler.sortShapes();

            //display the shorted shapes using the shape display object
            ShapeDisplay SDisplay = new ShapeDisplay(sortedShapes);
            SDisplay.displayAll();

        }

        //Code to override the macro Console's output

        public class ControlWriter : TextWriter
        {
            private TextBox textbox;
            public ControlWriter(TextBox textbox)
            {
                this.textbox = textbox;
            }

            public override void Write(char value)
            {
                textbox.Text += value;
            }

            public override void Write(string value)
            {
                textbox.Text += value;
            }

            public override Encoding Encoding
            {
                get { return Encoding.ASCII; }
            }
        }

        /*
        public void test()
        {   
            Point p = new Point(10, 50);
            Shape c = new Circle(p,1,15,"circle");
            Console.WriteLine(c.getLocation().ToString());
            c.display();
            Console.WriteLine(c.getDimensions());
            
        }*/
    }
}
