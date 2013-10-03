using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Azbuka
{
    public partial class Game4Form : Form
    {
        const int NUM_WORDS = 4;
        int difficulty;
        MultiWordQuestion currentQuestion;
        Stack<MultiWordQuestion> prevQuestions;
        SoundPlayer player;
        Image img;
        int failNum;
        int score;
        azbukaGame ag;
        Random rnd;

        public Game4Form(azbukaGame game)
        {
            InitializeComponent();
            ag = game;
            difficulty = 1;
            player = new SoundPlayer();
            rnd = new Random();
            img = null;
            failNum = 0;
            score = 0;
            currentQuestion = null;
            prevQuestions = new Stack<MultiWordQuestion>();
        }

        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                if (value > 0 && value <= 3) this.difficulty = value;
            }
        }

        public void getPrevQuest()
        {
            currentQuestion = this.prevQuestions.Pop();
            if (this.prevQuestions.Count == 0)
            {
                this.buttonPrev.Enabled = false;
            }

            displayQuest();
        }

        public void getNextQuest()
        {
            if (currentQuestion != null)
            {
                this.prevQuestions.Push(currentQuestion);
                this.buttonPrev.Enabled = true;
            }
            currentQuestion = new MultiWordQuestion();
            int minLen = 0;
            int maxLen = 0;
            switch (difficulty)
            {
                case 3:
                    minLen = 8;
                    maxLen = 20;
                    break;
                case 2:
                    minLen = 5;
                    maxLen = 7;
                    break;
                default:
                    minLen = 0;
                    maxLen = 4;
                    break;
            }
            currentQuestion.Words = ag.getRandomWords(NUM_WORDS, minLen, maxLen);
            currentQuestion.AnswerIndex = rnd.Next(NUM_WORDS);

            displayQuest();
        }

        public void displayQuest()
        {
            img = Image.FromFile(currentQuestion.Words[currentQuestion.AnswerIndex].imgFileName);

            // Figure out if the image has to be scaled down (we will not scale up)
            if (img.Width > this.pictureBox.Width || img.Height > this.pictureBox.Height)
            {
                this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                this.pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            this.pictureBox.Image = img;
            for (int i = 0; i < NUM_WORDS; i++)
            {
                this.btnDispl[i].Text = currentQuestion.Words[i].wordUpperCase;
            }
            failNum = 0;
            this.btnDispl[0].Select();
        }

        private void checkAnswer(string answer)
        {
            if (currentQuestion.Words[currentQuestion.AnswerIndex].wordUpperCase.Equals(answer))
            {   // correct
                player.SoundLocation = ag.getAnswer(true);
                player.Play();
                score++;
                this.scoreButton.Text = score.ToString();
                this.bottomPanel.Refresh();
                getNextQuest();
            }
            else
            {   // wrong
                if (failNum < azbukaGame.MAX_ATTEMPTS)
                {
                    this.failNum++;
                    player.SoundLocation = ag.getAnswer(false);
                    player.Play();
                }
                else
                {
                    getNextQuest();
                }
            }
        }


        // Event handlers

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            getPrevQuest();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            getNextQuest();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Add code to listen to the word
        }
        private void btnDispl_Enter(object sender, EventArgs e)
        {
            int index = (int)(((System.Windows.Forms.Button)sender).Tag);
            this.btnPanel[index].BackColor = Color.ForestGreen;
        }
        private void btnDispl_Leave(object sender, EventArgs e)
        {
            int index = (int)(((System.Windows.Forms.Button)sender).Tag);
            this.btnPanel[index].BackColor = SystemColors.Control;
        }
        private void btnDispl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int index = (int)(((System.Windows.Forms.Button)sender).Tag);
            if (e.KeyValue == 40) this.btnDispl[(index + 1) % NUM_WORDS].Focus();
            else if (e.KeyValue == 38) this.btnDispl[(index - 1 + NUM_WORDS) % NUM_WORDS].Focus();
        }
        private void btnDispl_Click(object sender, EventArgs e)
        {
            checkAnswer(((System.Windows.Forms.Button)sender).Text);
        }
        private void btnDispl_MouseEnter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Button)sender).Focus();
        }
        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < score; i++)
            {
                e.Graphics.DrawImage(prizeImg, 10 + i * (5 + prizeImg.Width), (BOTTOM_PANEL_HEIGHT - prizeImg.Height)/2);
            }
        }
    }
}
