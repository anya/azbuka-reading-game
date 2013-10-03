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
    public partial class Game3Form : Form
    {
        const int NUM_IMAGES = 6;
        azbukaGame ag;
        int difficulty;
        Stack<MultiWordQuestion> prevQuestions;
        MultiWordQuestion currentQuestion;
        Image[] images;
        Random rnd;
        int failNum;
        int score;
        SoundPlayer player;

        public Game3Form(azbukaGame game)
        {
            InitializeComponent();
            ag = game;
            difficulty = 1;
            rnd = new Random();
            images = new Image[NUM_IMAGES];
            for (int i = 0; i < NUM_IMAGES; i++) images[i] = null;
            failNum = 0;
            score = 0;
            player = new SoundPlayer();
            prevQuestions = new Stack<MultiWordQuestion>();
            currentQuestion = null;
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

        private void displayImage(Image img, PictureBox box)
        {
            if (img.Width > box.Width || img.Height > box.Height)
            {
                box.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                box.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            box.Image = img;
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
            switch(difficulty)
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
            currentQuestion.Words = ag.getRandomWords(NUM_IMAGES, minLen, maxLen);
            currentQuestion.AnswerIndex = rnd.Next(NUM_IMAGES);
            displayQuest();
        }

        public void displayQuest()
        {
            for (int i = 0; i < NUM_IMAGES; i++)
            {
                images[i] = Image.FromFile(currentQuestion.Words[i].imgFileName);
                displayImage(images[i], this.pictureBoxes[i]);
            }
            this.wordButton.Text = currentQuestion.Words[currentQuestion.AnswerIndex].wordUpperCase; ;
            this.failNum = 0;
            this.pictureBoxes[0].Select();
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

        private void checkAnswer(int a)
        {
            if (a == currentQuestion.AnswerIndex) // correct
            {
                player.SoundLocation = ag.getAnswer(true);
                player.Play();
                score++;
                this.scoreButton.Text = score.ToString();
                this.bottomPanel.Refresh();
                getNextQuest();
            }
            else // wrong
            {
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

        // Event handlers:

        private void innerPanel_Enter(object sender, EventArgs e)
        {
            int panelIndex = (int)(((System.Windows.Forms.Panel)sender).Tag);
            this.outerPanels[panelIndex].BackColor = Color.ForestGreen;
            this.pictureBoxes[panelIndex].Focus();
        }

        private void innerPanel_Leave(object sender, EventArgs e)
        {
            int panelIndex = (int)(((System.Windows.Forms.Panel)sender).Tag);
            this.outerPanels[panelIndex].BackColor = SystemColors.Control;
        }

        private void innerPanel_MouseEnter(object sender, EventArgs e)
        {
            int panelIndex = (int)(((System.Windows.Forms.Panel)sender).Tag);
            this.outerPanels[panelIndex].BackColor = Color.ForestGreen;
            this.pictureBoxes[panelIndex].Focus();
        }

        private void innerPanel_MouseClick(object sender, MouseEventArgs e)
        {
            int panelIndex = (int)(((System.Windows.Forms.Panel)sender).Tag);
            checkAnswer(panelIndex);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int index = (int)(((System.Windows.Forms.PictureBox)sender).Tag);
            checkAnswer(index);
        }

        private void pictureBox_MouseEnterHover(object sender, EventArgs e)
        {
            int index = (int)(((System.Windows.Forms.PictureBox)sender).Tag);
            this.innerPanels[index].Focus();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int index = (int)(((System.Windows.Forms.PictureBox)sender).Tag);
            this.innerPanels[index].Focus();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            getNextQuest();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            getPrevQuest();
        }

        private void pictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int index = (int)(((System.Windows.Forms.PictureBox)sender).Tag);
            if (e.KeyValue == 39) this.pictureBoxes[(index + 1) % NUM_IMAGES].Focus();
            else if (e.KeyValue == 37) this.pictureBoxes[(index - 1 + NUM_IMAGES) % NUM_IMAGES].Focus();
            else if (e.KeyValue == 40) this.pictureBoxes[(index + PICS_IN_ROW) % NUM_IMAGES].Focus();
            else if (e.KeyValue == 38) this.pictureBoxes[(index - PICS_IN_ROW + NUM_IMAGES) % NUM_IMAGES].Focus();
            else if (e.KeyValue == 13) checkAnswer(index);
        }

        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < score; i++)
            {
                e.Graphics.DrawImage(prizeImg, 10 + i * (5 + prizeImg.Width), (BOTTOM_AREA_HEIGHT - prizeImg.Height) / 2);
            }
        }

    }
}
