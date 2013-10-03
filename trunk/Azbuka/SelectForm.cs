using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azbuka
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
            ag = new azbukaGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game1Form g1f = new Game1Form(ag);
            this.Hide();
            g1f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game2Form g2f = new Game2Form(ag);
            this.Hide();
            g2f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game3Form g3f = new Game3Form(ag);
            g3f.Difficulty = 1;
            g3f.getNextQuest();
            this.Hide();
            g3f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game3Form g3f = new Game3Form(ag);
            g3f.Difficulty = 2;
            g3f.getNextQuest();
            this.Hide();
            g3f.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Game3Form g3f = new Game3Form(ag);
            g3f.Difficulty = 3;
            g3f.getNextQuest();
            this.Hide();
            g3f.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Game4Form g4f = new Game4Form(ag);
            g4f.Difficulty = 1;
            g4f.getNextQuest();
            this.Hide();
            g4f.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Game4Form g4f = new Game4Form(ag);
            g4f.Difficulty = 2;
            g4f.getNextQuest();
            this.Hide();
            g4f.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Game4Form g4f = new Game4Form(ag);
            g4f.Difficulty = 3;
            g4f.getNextQuest();
            this.Hide();
            g4f.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Game5Form g5f = new Game5Form(ag);
            g5f.Difficulty = 1;
            g5f.getNextQuest();
            this.Hide();
            g5f.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Game5Form g5f = new Game5Form(ag);
            g5f.Difficulty = 2;
            g5f.getNextQuest();
            this.Hide();
            g5f.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Game5Form g5f = new Game5Form(ag);
            g5f.Difficulty = 3;
            g5f.getNextQuest();
            this.Hide();
            g5f.ShowDialog();
            this.Show();
        }
    }
}
