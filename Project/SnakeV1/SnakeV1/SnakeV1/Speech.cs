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
        //Code for this class was found here: https://social.msdn.microsoft.com/Forums/vstudio/en-US/9c6eff5f-94a7-429b-b277-fee7c730bb1a/speech-recognition-in-workerthread?forum=csharpgeneral
        /// <summary>
        /// We edited this code quite a bit to meet the needs of this system, but the core events and functions are the same
        /// </summary>

        public Speech() : base()
        {
            runSpeech();
        }

        private void runSpeech()
        {
            CreateCommands();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(sre_RecognizeCompleted);
            Thread t = new Thread(delegate () { sre.SetInputToDefaultAudioDevice(); sre.RecognizeAsync(RecognizeMode.Single); });
            t.Start();
        }

        private void CreateCommands()
        {
            string[] commands = new string[] { "left", "right", "up", "down","luh","ruh","uh","duh" };
            Choices insChoices = new Choices(commands);
            GrammarBuilder insGrammarBuilder = new GrammarBuilder(insChoices);
            Grammar insGrammar = new Grammar(insGrammarBuilder);
            sre.LoadGrammar(insGrammar);
        }

        void sre_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            sre.RecognizeAsync();
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "left" || e.Result.Text == "luh")
            {
                direction = "left";
            }
            else if (e.Result.Text == "right" || e.Result.Text == "ruh")
            {
                direction = "right";
            }
            else if (e.Result.Text == "up" || e.Result.Text == "uh")
            {
                direction = "up";
            }
            else if (e.Result.Text == "down" || e.Result.Text == "duh")
            {
                direction = "down";
            }
        }

        public override void setType()
        {
            inputType = "speech";
        }
    }
}
