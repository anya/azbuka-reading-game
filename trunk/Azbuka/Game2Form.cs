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
    public partial class Game2Form : Form
    {
        const int NUM_IMAGES = 6;
        azbukaGame ag;
        Stack<MultiWordQuestion> prevQuestions;
        MultiWordQuestion currentQuestion;
        Image[] images;
        Random rnd;
        int failNum;
        int score;
        SoundPlayer player;

        public Game2Form(azbukaGame game)
        {
            InitializeComponent();
            ag = game;
            rnd = new Random();
            images = new Image[NUM_IMAGES];
            for (int i = 0; i < NUM_IMAGES; i++) images[i] = null;
            failNum = 0;
            score = 0;
            player = new SoundPlayer();
            prevQuestions = new Stack<MultiWordQuestion>();
            currentQuestion = null;
            getNextQuest();
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

        private void getNextQuest()
        {
            if (currentQuestion != null)
            {
                this.prevQuestions.Push(currentQuestion);
                this.buttonPrev.Enabled = true;
            }
            currentQuestion = new MultiWordQuestion();
            currentQuestion.Words = ag.getRandomWords(NUM_IMAGES, azbukaGame.FirstLetterCondition.AllDifferent);
            currentQuestion.AnswerIndex = rnd.Next(NUM_IMAGES);
            displayQuest();
        }

        private void displayQuest()
        {
            for (int i = 0; i < NUM_IMAGES; i++)
            {
                images[i] = Image.FromFile(currentQuestion.Words[i].imgFileName);
                displayImage(images[i], this.pictureBoxes[i]);
            }
            char letter = currentQuestion.Words[currentQuestion.AnswerIndex].wordUpperCase[0];
            this.letterButton.Text = letter.ToString();
            this.failNum = 0;
        }

        private void getPrevQuest()
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
                this.bottomPanel.Refresh();
                this.scoreButton.Text = score.ToString();
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
        }

        private void innerPanel_Leave(object sender, EventArgs e)
        {
            int panelIndex = (int)(((System.Windows.Forms.Panel)sender).Tag);
            this.outerPanels[panelIndex].BackColor = SystemColors.Control;
        }

        private void innerPanel_MouseEnter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Panel)sender).Focus();
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
        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < score; i++)
            {
                e.Graphics.DrawImage(prizeImg, 10 + i * (5 + prizeImg.Width), (BOTTOM_AREA_HEIGHT - prizeImg.Height) / 2);
            }
        }

    }
}
