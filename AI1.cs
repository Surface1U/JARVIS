using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace AI
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine speechRec = new SpeechRecognitionEngine();
        SpeechSynthesizer jarvis = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();
            speechRec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechRec_SpeechRecognized);
            LoadGrammar();
            speechRec.SetInputToDefaultAudioDevice();
            speechRec.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void LoadGrammar()
        {
            Choices texts = new Choices();
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\commands.txt");
            texts.Add(lines);
            Grammar wordlist = new Grammar(new GrammarBuilder(texts));
            speechRec.LoadGrammar(wordlist);

        }

        private void speechRec_SpeechRecognized (object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text;
            string speech = e.Result.Text;
            if(speech == "Hello")
            {
                jarvis.Speak("Hello there");
            }
            if(speech == "how are you?")
            {
                jarvis.Speak("Im fine lol man");
            }
            if (speech == "Who is your creator?")
            {
                jarvis.Speak("God..");
                System.Diagnostics.Process.Start("https://vk.com/");
            }
        }
    }
}
