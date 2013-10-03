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
    public partial class Game1Form : Form
    {
        Timer tm;
        qaFirstLetter quest;
        SoundPlayer player;
        Image img;
        int failNum;

        public Game1Form(azbukaGame game)
        {
            InitializeComponent();
            ag = game;
            player = new SoundPlayer();
            tm = new Timer();
            failNum = 0;
            tm.Tick += new EventHandler(tmHandler);
            tm.Interval = 10;
            tm.Start();
            //getNextQuest();
        }

        private void tmHandler(Object myObject, EventArgs myEventArgs)
        {
            getNextQuest();
        }

        private void getNextQuest()
        {
            tm.Stop();
            this.btnDispl1.Enabled = true;
            this.btnDispl2.Enabled = true;
            this.btnDispl3.Enabled = true;
            this.btnDispl4.Enabled = true;
            this.btnDispl5.Enabled = true;
            this.btnDispl6.Enabled = true;
            this.btnDispl1.Focus();

            quest = ag.getGame1Question(6);
            failNum = 0;
            img = Image.FromFile(quest.wordData.imgFileName);

            // Figure out if the image has to be scaled down (we will not scale up)
            if (img.Width > this.pictureBox1.Width || img.Height > this.pictureBox1.Height)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            this.pictureBox1.Image = img;
            this.answerLabel.Text = "?";
            this.btnDispl1.Text = quest.candidateLetters[0].ToString();
            this.btnDispl2.Text = quest.candidateLetters[1].ToString();
            this.btnDispl3.Text = quest.candidateLetters[2].ToString();
            this.btnDispl4.Text = quest.candidateLetters[3].ToString();
            this.btnDispl5.Text = quest.candidateLetters[4].ToString();
            this.btnDispl6.Text = quest.candidateLetters[5].ToString();
        }

        private void checkAnswer(string answer)
        {
            char let = answer[0];
            if (quest.wordData.wordUpperCase[0] == let)
            {   // correct
                this.answerLabel.Text = quest.wordData.wordUpperCase;
                player.SoundLocation = ag.getAnswer(true);
                player.Play();
                this.btnDispl1.Enabled = false;
                this.btnDispl2.Enabled = false;
                this.btnDispl3.Enabled = false;
                this.btnDispl4.Enabled = false;
                this.btnDispl5.Enabled = false;
                this.btnDispl6.Enabled = false;
                this.panel6.BackColor = SystemColors.Control;
                tm.Interval = 1500;
                tm.Start();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Add code to listen to the word
        }
        private void btnDispl1_Enter(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.ForestGreen;
        }
        private void btnDispl2_Enter(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.ForestGreen;
        }
        private void btnDispl3_Enter(object sender, EventArgs e)
        {
            this.panel3.BackColor = Color.ForestGreen;
        }
        private void btnDispl4_Enter(object sender, EventArgs e)
        {
            this.panel4.BackColor = Color.ForestGreen;
        }
        private void btnDispl5_Enter(object sender, EventArgs e)
        {
            this.panel5.BackColor = Color.ForestGreen;
        }
        private void btnDispl6_Enter(object sender, EventArgs e)
        {
            this.panel6.BackColor = Color.ForestGreen;
        }

        private void btnDispl1_Leave(object sender, EventArgs e)
        {
            this.panel1.BackColor = SystemColors.Control;
        }
        private void btnDispl2_Leave(object sender, EventArgs e)
        {
            this.panel2.BackColor = SystemColors.Control;
        }
        private void btnDispl3_Leave(object sender, EventArgs e)
        {
            this.panel3.BackColor = SystemColors.Control;
        }
        private void btnDispl4_Leave(object sender, EventArgs e)
        {
            this.panel4.BackColor = SystemColors.Control;
        }
        private void btnDispl5_Leave(object sender, EventArgs e)
        {
            this.panel5.BackColor = SystemColors.Control;
        }
        private void btnDispl6_Leave(object sender, EventArgs e)
        {
            this.panel6.BackColor = SystemColors.Control;
        }

        private void btnDispl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl2.Focus();
            else if (e.KeyValue == 38) this.btnDispl6.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl1.Text);
        }
        private void btnDispl2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl3.Focus();
            else if (e.KeyValue == 38) this.btnDispl1.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl2.Text);
        }
        private void btnDispl3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl4.Focus();
            else if (e.KeyValue == 38) this.btnDispl2.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl3.Text);
        }
        private void btnDispl4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl5.Focus();
            else if (e.KeyValue == 38) this.btnDispl3.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl4.Text);
        }
        private void btnDispl5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl6.Focus();
            else if (e.KeyValue == 38) this.btnDispl4.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl5.Text);
        }
        private void btnDispl6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 40) this.btnDispl1.Focus();
            else if (e.KeyValue == 38) this.btnDispl5.Focus();
            else if (e.KeyValue == 13) checkAnswer(this.btnDispl6.Text);
        }

        private void btnDispl1_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl1.Text);
        }
        private void btnDispl2_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl2.Text);
        }
        private void btnDispl3_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl3.Text);
        }
        private void btnDispl4_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl4.Text);
        }
        private void btnDispl5_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl5.Text);
        }
        private void btnDispl6_Click(object sender, EventArgs e)
        {
            checkAnswer(this.btnDispl6.Text);
        }

        private void btnDispl1_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl1.Focus();
        }
        private void btnDispl2_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl2.Focus();
        }
        private void btnDispl3_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl3.Focus();
        }
        private void btnDispl4_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl4.Focus();
        }
        private void btnDispl5_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl5.Focus();
        }
        private void btnDispl6_MouseEnter(object sender, EventArgs e)
        {
            this.btnDispl6.Focus();
        }
    }
}
