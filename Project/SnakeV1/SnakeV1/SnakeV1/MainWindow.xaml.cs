using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using Tobii.Interaction.Wpf;
using Tobii.Interaction;

namespace SnakeV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController gc; //The class that handles instantiating the game elements and refreshing the canvas
        private static WpfInteractorAgent _agent; //This is for gaze interactive UI elements in a WPF application
        private static Host _host; //hosts the connection to eye tracker 

        public MainWindow()
        {
            initHost(); 
            InitializeComponent();
            initGameController();
        }

        //Initialize GameController, this controls the timer that renders everything to the screen 
        // as well as the current input
        public void initGameController()
        {
           GameController newGame = new GameController(); 
           gc = newGame; 
        }

        private void Mouse_Click(object sender, RoutedEventArgs e)
        {
            //When mouse button is clicked, we want to change the input to Mouse 
            gc.setInputAsMouse();  
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            //When keyboard button is clicked, we want to change the input to keyboard 
            gc.setInputAsKeyboard(); 
        }
    
        private void GazeButton_Click(object sender, RoutedEventArgs e)
        {
            //When gaze button is clicked, we want to change the input to gaze
            gc.setInputAsGaze(); 
        }

        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            //When speech button is clicked, we want to change the input to speech
            gc.setInputAsSpeech();
        }

        private void Touch_Click(object sender, RoutedEventArgs e)
        {
            //When touch button is clicked, we want to change the input to touch
            gc.setInputAsTouch();
        }

        public void initHost()
        {
            _host = new Host();
            _agent = _host.InitializeWpfAgent();
        }
        

        private void easy_Click(object sender, RoutedEventArgs e)
        {
            //When easy is clicked, we want to hide menu options and set the game to easy mode
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            initGameController();
            gc.setLevel("easy");
            gc.newGame();
            gc.SetTimer("easy");
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            //When meduim is clicked, we want to hide menu options and set the game to medium mode
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            initGameController();
            gc.setLevel("medium");
            gc.newGame();
            gc.SetTimer("medium");
        }

        private void hard_Click(object sender, RoutedEventArgs e)
        {
            //When hard is clicked, we want to hide menu options and set the game to easy mode
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            initGameController();
            gc.setLevel("hard");
            gc.newGame();
            gc.SetTimer("hard");
        }

        
    }
}
