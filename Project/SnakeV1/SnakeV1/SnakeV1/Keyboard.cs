using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;

namespace SnakeV1
{
    class Keyboard : Input
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Keyboard() : base()
        {
            win.KeyDown += Win_KeyDown;
        }

        private void Win_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                direction = "down";
            }
            else if (e.Key == Key.Up)
            {
                direction = "up";
            }
            else if (e.Key == Key.Left)
            {
                direction = "left";
            }
            else if (e.Key == Key.Right)
            {
                direction = "right";
            }
        }

        public override void setType()
        {
            inputType = "keyboard"; 
        }



    }
}
