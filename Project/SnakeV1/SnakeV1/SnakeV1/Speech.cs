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
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                runSpeech();
            });
        }
        private void runSpeech()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            while (true)
            {
                String right = "right";
                String left = "left";
                String up = "up";
                String down = "down";
                try
                {
                    System.Console.WriteLine("Start talking!");
                    recognizer.SetInputToDefaultAudioDevice();
                    RecognitionResult result = recognizer.Recognize();
                    System.Console.WriteLine(result.Text);
                    if (result.Equals(right))
                    {
                        direction = "right";
                    }
                    else if (result.Equals(left))
                    {
                        direction = "left";
                    }
                    else if (result.Equals(up))
                    {
                        direction = "down";
                    }
                    else if (result.Equals(down))
                    {
                        direction = "left";
                    }
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
            }
            System.Console.ReadKey(true);
        }

        public override void setType()
        {
            inputType = "speech";
        }



    }
}
