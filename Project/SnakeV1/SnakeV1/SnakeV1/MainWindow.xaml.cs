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
        GameController gc;
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        private static WpfInteractorAgent _agent;
        private static Host _host; //hosts the connection to eye tracker 

        private static GazePointDataStream _gazePointDataStream; //gets eye gaze from tracker

        public MainWindow()
        {
            initHost(); 
            InitializeComponent();
            test();
            //printCanvasChildren();
        }

        public void test()
        {
           GameController newGame = new GameController(); 
           gc = newGame; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gc.setInputAsMouse();  
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            gc.setInputAsKeyboard(); 
        }
    
        private void GazeButton_Click(object sender, RoutedEventArgs e)
        {
            gc.setInputAsGaze(); 
        }

        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            gc.setInputAsSpeech();
        }

        private void Touch_Click(object sender, RoutedEventArgs e)
        {
            gc.setInputAsTouch();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateAndVisualizeUnfilteredGazePointStream(); 
        }

        public void initHost()
        {
            _host = new Host();
            _agent = _host.InitializeWpfAgent();
        }

        private static void CreateAndVisualizeUnfilteredGazePointStream()
        {
            if (_gazePointDataStream != null)
                _gazePointDataStream.Next -= OnNextGazePoint;

            _gazePointDataStream = _host.Streams.CreateGazePointDataStream(Tobii.Interaction.Framework.GazePointDataMode.Unfiltered);
            _gazePointDataStream.Next += OnNextGazePoint;
        }

        private static void OnNextGazePoint(object sender, StreamData<GazePointData> gazePoint)
        {
            //Uncomment next line to see eye tracker output
            //Console.WriteLine("Timestamp: {0}\t,X:{1}, Y:{2}" + gazePoint.Data.Timestamp.ToString() + "\t" + gazePoint.Data.X.ToString() + "\t" + gazePoint.Data.Y.ToString());

            string X = "";
            string Y = "";
            string TS = "";

            X = gazePoint.Data.X.ToString();
            Y = gazePoint.Data.Y.ToString();
            TS = gazePoint.Data.Timestamp.ToString();
            string SystemTS = DateTime.Now.ToString("mm:ss.ffffff");

            //format gaze data for txt file
            string data = TS + "," + X + "," + Y + "," + SystemTS;

        }

        //test function
        private void printCanvasChildren()
        {
            foreach(UIElement r in GameCanvas.Children)
            {
                 System.Windows.Shapes.Rectangle R = (System.Windows.Shapes.Rectangle)r;
                Console.WriteLine(R.Name); 
            }
        }

        private void easy_Click(object sender, RoutedEventArgs e)
        {
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            test();
            gc.setLevel("easy");
            gc.newGame();
            gc.SetTimer("easy");
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            test();
            gc.setLevel("medium");
            gc.newGame();
            gc.SetTimer("medium");
        }

        private void hard_Click(object sender, RoutedEventArgs e)
        {
            GameCanvas.Background = Brushes.LightGray;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            gameText.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            test();
            gc.setLevel("hard");
            gc.newGame();
            gc.SetTimer("hard");
        }
    }
}
