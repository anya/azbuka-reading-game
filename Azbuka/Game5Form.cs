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
    public partial class Game5Form : Form
    {
        const int NUM_LETTERS = 6;
        azbukaGame ag;
        int difficulty;
        SingleWordQuestion currentQuestion;
        Stack<SingleWordQuestion> prevQuestions;
        SoundPlayer player;
        Random rnd;
        Image img;
        int failNum;
        int score;

        public Game5Form(azbukaGame game)
        {
            InitializeComponent();
            ag = game;
            difficulty = 1;
            currentQuestion = null;
            prevQuestions = new Stack<SingleWordQuestion>();
            player = new SoundPlayer();
            rnd = new Random();
            failNum = 0;
            score = 0;
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

        public void getNextQuest()
        {
            if (currentQuestion != null)
            {
                this.prevQuestions.Push(currentQuestion);
                this.buttonPrev.Enabled = true;
            }
            currentQuestion = new SingleWordQuestion(ag, difficulty, NUM_LETTERS, rnd);
            displayQuest();
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

        private void displayQuest()
        {
            failNum = 0;
            img = Image.FromFile(currentQuestion.PictureFile);

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
            this.wordLabel.Text = currentQuestion.MissingLetterText;

            for (int i = 0; i < NUM_LETTERS; i++)
            {
                this.btnDispl[i].Text = currentQuestion.CandidateLetters[i].ToString();
            }

            this.btnDispl[0].Select();
        }

        private void checkAnswer(string answer)
        {
            char let = answer[0];
            if (currentQuestion.AnswerLetter == let)
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
                else getNextQuest();
            }
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
            if (e.KeyValue == 39) this.btnDispl[(index + 1) % NUM_LETTERS].Focus();
            else if (e.KeyValue == 37) this.btnDispl[(index - 1 + NUM_LETTERS) % NUM_LETTERS].Focus();
            else if (e.KeyValue == 40) this.btnDispl[(index + LETTERS_IN_ROW) % NUM_LETTERS].Focus();
            else if (e.KeyValue == 38) this.btnDispl[(index - LETTERS_IN_ROW + NUM_LETTERS) % NUM_LETTERS].Focus();
        }

        private void btnDispl_Click(object sender, EventArgs e)
        {
            checkAnswer(((System.Windows.Forms.Button)sender).Text);
        }

        private void btnDispl_MouseEnter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Button)sender).Focus();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            getNextQuest();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            getPrevQuest();
        }
        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < score; i++)
            {
                e.Graphics.DrawImage(prizeImg, 10 + i * (5 + prizeImg.Width), (BOTTOM_PANEL_HEIGHT - prizeImg.Height) / 2);
            }
        }
    }
}
