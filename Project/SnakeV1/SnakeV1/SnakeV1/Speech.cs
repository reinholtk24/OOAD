using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Speech.Recognition;
using System.Threading;

namespace SnakeV1
{
    class Speech : Input
    {
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        private MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Speech() : base()
        {
                runSpeech();
        }

        private void runSpeech()
        {
            CreateCommands();
            sre.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(sre_SpeechDetected);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(sre_RecognizeCompleted);
            sre.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sre_SpeechRecognitionRejected);
            Thread t = new Thread(delegate () { sre.SetInputToDefaultAudioDevice(); sre.RecognizeAsync(RecognizeMode.Single); });
            t.Start();
        }

        private void CreateCommands()
        {
            string[] commands = new string[] { "left", "right", "up", "down" };
            Choices insChoices = new Choices(commands);
            GrammarBuilder insGrammarBuilder = new GrammarBuilder(insChoices);
            Grammar insGrammar = new Grammar(insGrammarBuilder);
            sre.LoadGrammar(insGrammar);
        }

        void sre_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {

        }

        void sre_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            sre.RecognizeAsync();

        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "left")
            {
                direction = "left";
            }
            else if (e.Result.Text == "right")
            {
                direction = "right";
            }
            else if (e.Result.Text == "up")
            {
                direction = "up";
            }
            else if (e.Result.Text == "down")
            {
                direction = "down";
            }


        }

        void sre_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {

        }

        public override void setType()
        {
            inputType = "speech";
        }
    }
}
