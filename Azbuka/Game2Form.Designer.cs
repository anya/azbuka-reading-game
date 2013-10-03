namespace Azbuka
{
    partial class Game2Form
    {
        private const int PANEL_WIDTH = 200;
        private const int PANEL_HEIGHT = 180;
        private const int PANEL_BORDER = 4;
        private const int PICTURE_WIDTH = 160;
        private const int PICTURE_HEIGHT = 140;
        private const int HORIZ_SPACE = 32;
        private const int VERT_SPACE = 26;
        private const int PICS_IN_ROW = 3;
        private const int LETTER_BTN_WIDTH = 120;
        private const int LETTER_BTN_HEIGHT = 120;
        private const int NAV_BTN_HEIGHT = 80;
        private const int NAV_BTN_WIDTH = 100;
        private const int TOP_AREA_HEIGHT = 170;
        private const int BOTTOM_AREA_HEIGHT = 60;
        private const int FORM_BORDER = 4;
        private const int FORM_WIDTH = (PANEL_WIDTH + HORIZ_SPACE) * PICS_IN_ROW + HORIZ_SPACE;
        private const int FORM_HEIGHT = TOP_AREA_HEIGHT + BOTTOM_AREA_HEIGHT + VERT_SPACE / 2 + VERT_SPACE + PANEL_HEIGHT * 2;
        private const int SCORE_BTN_WIDTH = 67;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game2Form));
            this.prizeImg = (System.Drawing.Image)(resources.GetObject("Apple"));

            this.letterButton = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.scoreButton = new System.Windows.Forms.Button();

            this.outerPanels = new System.Windows.Forms.Panel[NUM_IMAGES];
            this.innerPanels = new System.Windows.Forms.Panel[NUM_IMAGES];
            this.pictureBoxes = new System.Windows.Forms.PictureBox[NUM_IMAGES];
            
            for (int i = 0; i < NUM_IMAGES; i++)
            {
                this.outerPanels[i] = new System.Windows.Forms.Panel();
                this.innerPanels[i] = new System.Windows.Forms.Panel();
                this.pictureBoxes[i] = new System.Windows.Forms.PictureBox();
                this.outerPanels[i].SuspendLayout();
                this.innerPanels[i].SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxes[i])).BeginInit();
            }

            this.SuspendLayout();

            for (int i = 0; i < NUM_IMAGES; i++)
            {
                this.outerPanels[i].Tag = i;
                this.outerPanels[i].BackColor = System.Drawing.SystemColors.Control;
                this.outerPanels[i].Size = new System.Drawing.Size(PANEL_WIDTH + PANEL_BORDER * 2, PANEL_HEIGHT + PANEL_BORDER * 2);
                this.outerPanels[i].Name = "panel" + i.ToString();
                this.outerPanels[i].Controls.Add(this.innerPanels[i]);
                this.outerPanels[i].TabStop = false;
                this.outerPanels[i].Location = new System.Drawing.Point(HORIZ_SPACE + (PANEL_WIDTH + HORIZ_SPACE) * (i % PICS_IN_ROW), 
                                                                        TOP_AREA_HEIGHT + (PANEL_HEIGHT + VERT_SPACE) * (i / PICS_IN_ROW));
                this.innerPanels[i].Tag = i;
                this.innerPanels[i].BackColor = System.Drawing.Color.White;
                this.innerPanels[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.innerPanels[i].Size = new System.Drawing.Size(PANEL_WIDTH, PANEL_HEIGHT);
                this.innerPanels[i].Controls.Add(this.pictureBoxes[i]);
                this.innerPanels[i].Name = "panel" + i.ToString() + "a";
                this.innerPanels[i].TabStop = false;
                this.innerPanels[i].Location = new System.Drawing.Point(PANEL_BORDER, PANEL_BORDER);
                this.innerPanels[i].Leave += new System.EventHandler(this.innerPanel_Leave);
                this.innerPanels[i].MouseClick += new System.Windows.Forms.MouseEventHandler(this.innerPanel_MouseClick);
                this.innerPanels[i].Enter += new System.EventHandler(this.innerPanel_Enter);
                this.innerPanels[i].MouseEnter += new System.EventHandler(this.innerPanel_MouseEnter);

                this.pictureBoxes[i].Tag = i;
                this.pictureBoxes[i].BackColor = System.Drawing.Color.White;
                this.pictureBoxes[i].Size = new System.Drawing.Size(PICTURE_WIDTH, PICTURE_HEIGHT);
                this.pictureBoxes[i].Name = "pictureBox" + i.ToString();
                this.pictureBoxes[i].Location = new System.Drawing.Point((PANEL_WIDTH - PICTURE_WIDTH) / 2, (PANEL_HEIGHT - PICTURE_HEIGHT) / 2);
                this.pictureBoxes[i].TabStop = true;
                this.pictureBoxes[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
                this.pictureBoxes[i].Click += new System.EventHandler(this.pictureBox_Click);
                this.pictureBoxes[i].MouseHover += new System.EventHandler(this.pictureBox_MouseEnterHover);
                this.pictureBoxes[i].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnterHover);
            
            }

            // 
            // letterButton
            // 
            this.letterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.letterButton.Location = new System.Drawing.Point(this.outerPanels[1].Location.X + (this.outerPanels[1].Width - LETTER_BTN_WIDTH) / 2, 
                                                                  (TOP_AREA_HEIGHT - LETTER_BTN_HEIGHT) / 2);
            this.letterButton.Name = "letterButton";
            this.letterButton.Size = new System.Drawing.Size(LETTER_BTN_WIDTH, LETTER_BTN_HEIGHT);
            this.letterButton.TabStop = false;
            this.letterButton.Text = "A";
            this.letterButton.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(this.outerPanels[2].Location.X + (this.outerPanels[2].Width - NAV_BTN_WIDTH) / 2,
                                                                (TOP_AREA_HEIGHT - NAV_BTN_HEIGHT) / 2);
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(NAV_BTN_WIDTH, NAV_BTN_HEIGHT);
            this.buttonNext.TabIndex = 10;
            this.buttonNext.Text = "";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(this.outerPanels[0].Location.X + (this.outerPanels[0].Width - NAV_BTN_WIDTH) / 2, 
                                                                (TOP_AREA_HEIGHT - NAV_BTN_HEIGHT) / 2);
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(NAV_BTN_WIDTH, NAV_BTN_HEIGHT);
            this.buttonPrev.TabIndex = 11;
            this.buttonPrev.Text = "";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Enabled = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(FORM_WIDTH, BOTTOM_AREA_HEIGHT);
            this.bottomPanel.Controls.Add(this.scoreButton);
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
            // Game2Form
            // 
            this.Name = "Game2Form";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "Азбука - Подбери картинку к букве";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(FORM_WIDTH + FORM_BORDER * 2, FORM_HEIGHT + FORM_BORDER + 20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.letterButton);
            
            for (int i = 0; i < NUM_IMAGES; i++)
            {
                this.Controls.Add(this.outerPanels[i]);
                this.outerPanels[i].ResumeLayout(false);
                this.innerPanels[i].ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxes[i])).EndInit();
            }

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel[] outerPanels;
        private System.Windows.Forms.Panel[] innerPanels;
        private System.Windows.Forms.PictureBox[] pictureBoxes;
        private System.Windows.Forms.Button letterButton;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button scoreButton;

    }
}