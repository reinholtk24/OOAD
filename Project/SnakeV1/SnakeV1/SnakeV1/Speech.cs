using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Speech.Recognition;

namespace SnakeV1
{
    class Speech : Input
    {
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Speech() : base()
        {
            win.KeyDown += Win_KeyDown;
        }

        static void Main() {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                System.Console.WriteLine("Start talking!");
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                System.Console.WriteLine(result.Text);
            }
            catch (InvalidOperationException exception)
            {
                System.Console.WriteLine(
                    String.Format(
                        "Could not recognize input; {0}: '{1}'.",
                         exception.GetType(), exception.Message));
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }
            System.Console.WriteLine("Done. Press any key...");
            System.Console.ReadKey(true);
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
            inputType = "speech";
        }



    }
}
