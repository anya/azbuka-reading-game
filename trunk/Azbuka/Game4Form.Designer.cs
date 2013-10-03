using System;

namespace Azbuka
{
    partial class Game4Form
    {
        private const int PICTURE_PANEL_WIDTH = 266;
        private const int PICTURE_PANEL_HEIGHT = 236;
        private const int PICTURE_WIDTH = 212;
        private const int PICTURE_HEIGHT = 182;

        private const int WORD_BTN_WIDTH = 300;
        private const int WORD_BTN_HEIGHT = 70;
        private const int WORD_BTN_BORDER = 4;
        private const int WORD_PANEL_WIDTH = WORD_BTN_WIDTH + WORD_BTN_BORDER * 2;
        private const int WORD_PANEL_HEIGHT = WORD_BTN_HEIGHT + WORD_BTN_BORDER * 2;

        private const int FORM_PADDING = 30;
        private const int HORIZ_SPACE = 48;
        private const int VERT_SPACE = 24;

        private const int NAV_BTN_WIDTH = 100;
        private const int NAV_BTN_HEIGHT = 90;
        private const int BOTTOM_PANEL_HEIGHT = 52;
        private const int SCORE_BTN_WIDTH = 67;

        private int FORM_WIDTH =    FORM_PADDING * 2
                                        + PICTURE_PANEL_WIDTH
                                        + HORIZ_SPACE
                                        + WORD_BTN_WIDTH;

        private int FORM_HEIGHT =   FORM_PADDING * 2 
                                        + BOTTOM_PANEL_HEIGHT
                                        + WORD_BTN_HEIGHT * Math.Max(NUM_WORDS, 4)
                                        + VERT_SPACE * (Math.Max(NUM_WORDS, 4) - 1);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game4Form));
            this.prizeImg = (System.Drawing.Image)(resources.GetObject("Apple"));

            this.pictBoxPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.scoreButton = new System.Windows.Forms.Button();

            this.btnDispl = new System.Windows.Forms.Button[NUM_WORDS];
            this.btnPanel = new System.Windows.Forms.Panel[NUM_WORDS];
            for (int i = 0; i < NUM_WORDS; i++)
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
            // word buttons and background panels
            // 
            for (int i = 0; i < NUM_WORDS; i++)
            {
                this.btnDispl[i].Tag = i;
                this.btnDispl[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.btnDispl[i].Location = new System.Drawing.Point(WORD_BTN_BORDER, WORD_BTN_BORDER);
                this.btnDispl[i].Name = "btnDispl_" + i.ToString();
                this.btnDispl[i].Size = new System.Drawing.Size(WORD_BTN_WIDTH, WORD_BTN_HEIGHT);
                this.btnDispl[i].UseVisualStyleBackColor = true;
                this.btnDispl[i].PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl_PreviewKeyDown);
                this.btnDispl[i].Click += new System.EventHandler(this.btnDispl_Click);
                this.btnDispl[i].Leave += new System.EventHandler(this.btnDispl_Leave);
                this.btnDispl[i].Enter += new System.EventHandler(this.btnDispl_Enter);
                this.btnDispl[i].MouseEnter += new System.EventHandler(this.btnDispl_MouseEnter);

                this.btnPanel[i].Tag = i;
                this.btnPanel[i].BackColor = System.Drawing.SystemColors.Control;
                this.btnPanel[i].Controls.Add(this.btnDispl[i]);
                this.btnPanel[i].Location = new System.Drawing.Point(FORM_PADDING + PICTURE_PANEL_WIDTH + HORIZ_SPACE, 
                                                                     FORM_PADDING + (WORD_BTN_HEIGHT + VERT_SPACE) * i - WORD_BTN_BORDER);
                this.btnPanel[i].Name = "panel_" + i.ToString();
                this.btnPanel[i].Size = new System.Drawing.Size(WORD_PANEL_WIDTH, WORD_PANEL_HEIGHT);
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
            this.pictBoxPanel.TabIndex = 15;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point((PICTURE_PANEL_WIDTH - PICTURE_WIDTH) / 2,
                                                                (PICTURE_PANEL_HEIGHT - PICTURE_HEIGHT) / 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(PICTURE_WIDTH, PICTURE_HEIGHT);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(FORM_PADDING + (PICTURE_PANEL_WIDTH - NAV_BTN_WIDTH),
                                                                FORM_PADDING + WORD_BTN_HEIGHT * 4 + VERT_SPACE * 3 - NAV_BTN_HEIGHT);
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
                                                                FORM_PADDING + WORD_BTN_HEIGHT * 4 + VERT_SPACE * 3 - NAV_BTN_HEIGHT);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(NAV_BTN_WIDTH, NAV_BTN_HEIGHT);
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(10, BOTTOM_PANEL_HEIGHT);
            this.bottomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bottomPanel_Paint);
            this.bottomPanel.Controls.Add(this.scoreButton);
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
            this.scoreButton.UseVisualStyleBackColor = false;
            
            // 
            // Game4Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(FORM_WIDTH, FORM_HEIGHT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game4Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Азбука - Найди слово по картинке";
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.pictBoxPanel);
            for (int i = 0; i < NUM_WORDS; i++)
            {
                this.Controls.Add(this.btnPanel[i]);
                this.btnPanel[i].ResumeLayout(false);
                this.btnPanel[i].Enabled = true;
                this.btnPanel[i].Visible = true;
            }
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
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button scoreButton;

    }
}

