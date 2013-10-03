using System;

namespace Azbuka
{
    partial class Game5Form
    {
        private const int PICTURE_PANEL_WIDTH = 260;
        private const int PICTURE_PANEL_HEIGHT = 210;
        private const int PICTURE_WIDTH = 220;
        private const int PICTURE_HEIGHT = 170;

        private const int LETTER_BTN_SIZE = 110;
        private const int LETTER_BTN_BORDER = 4;
        private const int LETTER_PANEL_SIZE = LETTER_BTN_SIZE + LETTER_BTN_BORDER * 2;
        private const int LETTERS_IN_ROW = 2;
        
        private const int FORM_PADDING = 30;
        private const int HORIZ_SPACE = 40;
        private const int VERT_SPACE = 16;

        private const int WORD_LABEL_WIDTH = 286;
        private const int WORD_LABEL_HEIGHT = 54;
        private const int NAV_BTN_WIDTH = 110;
        private const int NAV_BTN_HEIGHT = 76;
        private const int BOTTOM_PANEL_HEIGHT = 52;
        private const int SCORE_BTN_WIDTH = 67;

        private int NUM_LETTER_ROWS;
        private int FORM_WIDTH;
        private int FORM_HEIGHT;

        private System.Drawing.Image prizeImg;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NUM_LETTER_ROWS = (int)Math.Ceiling((double)NUM_LETTERS / (double)LETTERS_IN_ROW);
            this.FORM_WIDTH  = FORM_PADDING * 2
                             + PICTURE_PANEL_WIDTH
                             + HORIZ_SPACE
                             + LETTER_BTN_SIZE * LETTERS_IN_ROW
                             + VERT_SPACE * (LETTERS_IN_ROW - 1);

            this.FORM_HEIGHT = FORM_PADDING * 2
                             + BOTTOM_PANEL_HEIGHT
                             + LETTER_BTN_SIZE * Math.Max(NUM_LETTER_ROWS, 3)
                             + VERT_SPACE * (Math.Max(NUM_LETTER_ROWS, 3) - 1);


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game5Form));
            this.prizeImg = (System.Drawing.Image)(resources.GetObject("Apple"));

            this.btnDispl = new System.Windows.Forms.Button[NUM_LETTERS];
            this.btnPanel = new System.Windows.Forms.Panel[NUM_LETTERS];
            this.pictBoxPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.wordLabel = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.scoreButton = new System.Windows.Forms.Button();
            for (int i = 0; i < NUM_LETTERS; i++)
            {
                this.btnDispl[i] = new System.Windows.Forms.Button();
                this.btnPanel[i] = new System.Windows.Forms.Panel();
                this.btnPanel[i].SuspendLayout();
            }
            this.pictBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // Letter buttons and background panels
            // 
            for (int i = 0; i < NUM_LETTERS; i++)
            {
                int x = FORM_PADDING + PICTURE_PANEL_WIDTH + HORIZ_SPACE + (LETTER_BTN_SIZE + VERT_SPACE) * (i % LETTERS_IN_ROW);
                int y = FORM_PADDING + (LETTER_BTN_SIZE + VERT_SPACE) * (i / LETTERS_IN_ROW) - LETTER_BTN_BORDER;
                this.btnPanel[i].BackColor = System.Drawing.SystemColors.Control;
                this.btnPanel[i].Location = new System.Drawing.Point(x, y);
                this.btnPanel[i].Name = "panel_" + i.ToString();
                this.btnPanel[i].Size = new System.Drawing.Size(LETTER_PANEL_SIZE, LETTER_PANEL_SIZE);
                this.btnPanel[i].TabStop = false;
                this.btnPanel[i].Tag = i;
                this.btnPanel[i].Controls.Add(this.btnDispl[i]);

                this.btnDispl[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.btnDispl[i].Location = new System.Drawing.Point(LETTER_BTN_BORDER, LETTER_BTN_BORDER);
                this.btnDispl[i].Name = "btnDispl_" + i.ToString();
                this.btnDispl[i].Size = new System.Drawing.Size(LETTER_BTN_SIZE, LETTER_BTN_SIZE);
                this.btnDispl[i].Text = "A";
                this.btnDispl[i].UseVisualStyleBackColor = true;
                this.btnDispl[i].Tag = i;
                this.btnDispl[i].PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl_PreviewKeyDown);
                this.btnDispl[i].Click += new System.EventHandler(this.btnDispl_Click);
                this.btnDispl[i].Leave += new System.EventHandler(this.btnDispl_Leave);
                this.btnDispl[i].Enter += new System.EventHandler(this.btnDispl_Enter);
                this.btnDispl[i].MouseEnter += new System.EventHandler(this.btnDispl_MouseEnter);
            }

            // 
            // pictBoxPanel
            // 
            this.pictBoxPanel.BackColor = System.Drawing.Color.White;
            this.pictBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictBoxPanel.Controls.Add(this.pictureBox);
            this.pictBoxPanel.Location = new System.Drawing.Point(FORM_PADDING, FORM_PADDING);
            this.pictBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pictBoxPanel.Name = "pictBoxPanel";
            this.pictBoxPanel.Size = new System.Drawing.Size(PICTURE_PANEL_WIDTH, PICTURE_PANEL_HEIGHT);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point((PICTURE_PANEL_WIDTH - PICTURE_WIDTH) / 2,
                                                                 (PICTURE_PANEL_HEIGHT - PICTURE_HEIGHT) / 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(PICTURE_WIDTH, PICTURE_HEIGHT);
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // wordLabel
            // 
            this.wordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordLabel.Location = new System.Drawing.Point(FORM_PADDING - (WORD_LABEL_WIDTH - PICTURE_PANEL_WIDTH) / 2, 
                                                               FORM_PADDING + PICTURE_PANEL_HEIGHT + VERT_SPACE);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(WORD_LABEL_WIDTH, WORD_LABEL_HEIGHT);
            this.wordLabel.Text = "";
            this.wordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(FORM_PADDING + (PICTURE_PANEL_WIDTH - NAV_BTN_WIDTH),
                                                                FORM_PADDING + LETTER_BTN_SIZE * 3 + VERT_SPACE * 2 - NAV_BTN_HEIGHT);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(NAV_BTN_WIDTH, NAV_BTN_HEIGHT);
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Enabled = false;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(FORM_PADDING,
                                                                FORM_PADDING + LETTER_BTN_SIZE * 3 + VERT_SPACE * 2 - NAV_BTN_HEIGHT);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(NAV_BTN_WIDTH, NAV_BTN_HEIGHT);
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomPanel.Controls.Add(this.scoreButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(10, BOTTOM_PANEL_HEIGHT);
            this.bottomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bottomPanel_Paint);
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(215)))));
            this.scoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(215)))));
            this.scoreButton.FlatAppearance.BorderSize = 0;
            this.scoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(215)))));
            this.scoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(215)))));
            this.scoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(SCORE_BTN_WIDTH, 20);
            this.scoreButton.Text = "0";
            this.scoreButton.TabStop = false;
            this.scoreButton.UseVisualStyleBackColor = false;
            // 
            // Game5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(FORM_WIDTH, FORM_HEIGHT);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.pictBoxPanel);
            for (int i = 0; i < NUM_LETTERS; i++)
            {
                this.Controls.Add(this.btnPanel[i]);
                this.btnPanel[i].Enabled = true;
                this.btnPanel[i].Visible = true;
            }

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game5Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Азбука - Пропущенные буквы";
            this.pictBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button[] btnDispl;
        private System.Windows.Forms.Panel[] btnPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel pictBoxPanel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button scoreButton;

    }
}
