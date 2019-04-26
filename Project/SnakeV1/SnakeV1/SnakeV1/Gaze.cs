using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;
using System.Windows; 

namespace SnakeV1
{
    class Gaze : Input
    {   
        public Gaze()
        {
            //Add gaze behavior events to the gaze buttons on the main window
            win.GazeUp.AddHasGazeChangedHandler(gazeUp);
            win.GazeDown.AddHasGazeChangedHandler(gazeDown);
            win.GazeLeft.AddHasGazeChangedHandler(gazeLeft);
            win.GazeRight.AddHasGazeChangedHandler(gazeRight);
            makeVisible(); 
        }

        public void makeVisible()
        {
            win.GazeUp.Visibility = Visibility.Visible;
            win.GazeDown.Visibility = Visibility.Visible;
            win.GazeLeft.Visibility = Visibility.Visible;
            win.GazeRight.Visibility = Visibility.Visible;
        }

        public override void hide()
        {
            win.GazeUp.Visibility = Visibility.Hidden;
            win.GazeDown.Visibility = Visibility.Hidden;
            win.GazeLeft.Visibility = Visibility.Hidden;
            win.GazeRight.Visibility = Visibility.Hidden;
        }

        private void gazeRight(object sender, HasGazeChangedRoutedEventArgs e)
        {
            //If the right gaze button has gaze, then set the direction for the snake to travel to the right. 
            if (e.HasGaze == true)
            {
                direction = "right";
            }
        }

        private void gazeLeft(object sender, HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze == true)
            {
                direction = "left";
            }
        }

        private void gazeDown(object sender, HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze == true)
            {
                direction = "down";
            }
        }

        private void gazeUp(object sender, HasGazeChangedRoutedEventArgs e)
        {
            if(e.HasGaze == true)
            {
                direction = "up"; 
            }
            
        }

        public override void setType()
        {
            inputType = "gaze"; 
        }

    }
}
