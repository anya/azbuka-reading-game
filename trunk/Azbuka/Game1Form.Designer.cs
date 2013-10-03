namespace Azbuka
{
    partial class Game1Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        azbukaGame ag;

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

            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDispl1 = new System.Windows.Forms.Button();
            this.btnDispl2 = new System.Windows.Forms.Button();
            this.btnDispl3 = new System.Windows.Forms.Button();
            this.btnDispl4 = new System.Windows.Forms.Button();
            this.btnDispl6 = new System.Windows.Forms.Button();
            this.btnDispl5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictBoxPanel = new System.Windows.Forms.Panel();
            this.answerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(40, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 220);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnDispl1
            // 
            this.btnDispl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl1.Location = new System.Drawing.Point(382, 26);
            this.btnDispl1.Name = "btnDispl1";
            this.btnDispl1.Size = new System.Drawing.Size(110, 110);
            this.btnDispl1.TabIndex = 9;
            this.btnDispl1.Text = "A";
            this.btnDispl1.UseVisualStyleBackColor = true;
            this.btnDispl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl1_PreviewKeyDown);
            this.btnDispl1.Click += new System.EventHandler(this.btnDispl1_Click);
            this.btnDispl1.Leave += new System.EventHandler(this.btnDispl1_Leave);
            this.btnDispl1.Enter += new System.EventHandler(this.btnDispl1_Enter);
            this.btnDispl1.MouseEnter += new System.EventHandler(this.btnDispl1_MouseEnter);
            // 
            // btnDispl2
            // 
            this.btnDispl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl2.Location = new System.Drawing.Point(510, 26);
            this.btnDispl2.Name = "btnDispl2";
            this.btnDispl2.Size = new System.Drawing.Size(110, 110);
            this.btnDispl2.TabIndex = 11;
            this.btnDispl2.Text = "A";
            this.btnDispl2.UseVisualStyleBackColor = true;
            this.btnDispl2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl2_PreviewKeyDown);
            this.btnDispl2.Click += new System.EventHandler(this.btnDispl2_Click);
            this.btnDispl2.Leave += new System.EventHandler(this.btnDispl2_Leave);
            this.btnDispl2.Enter += new System.EventHandler(this.btnDispl2_Enter);
            this.btnDispl2.MouseEnter += new System.EventHandler(this.btnDispl2_MouseEnter);
            // 
            // btnDispl3
            // 
            this.btnDispl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl3.Location = new System.Drawing.Point(382, 154);
            this.btnDispl3.Name = "btnDispl3";
            this.btnDispl3.Size = new System.Drawing.Size(110, 110);
            this.btnDispl3.TabIndex = 12;
            this.btnDispl3.Text = "A";
            this.btnDispl3.UseVisualStyleBackColor = true;
            this.btnDispl3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl3_PreviewKeyDown);
            this.btnDispl3.Click += new System.EventHandler(this.btnDispl3_Click);
            this.btnDispl3.Leave += new System.EventHandler(this.btnDispl3_Leave);
            this.btnDispl3.Enter += new System.EventHandler(this.btnDispl3_Enter);
            this.btnDispl3.MouseEnter += new System.EventHandler(this.btnDispl3_MouseEnter);
            // 
            // btnDispl4
            // 
            this.btnDispl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl4.Location = new System.Drawing.Point(509, 154);
            this.btnDispl4.Name = "btnDispl4";
            this.btnDispl4.Size = new System.Drawing.Size(110, 110);
            this.btnDispl4.TabIndex = 13;
            this.btnDispl4.Text = "A";
            this.btnDispl4.UseVisualStyleBackColor = true;
            this.btnDispl4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl4_PreviewKeyDown);
            this.btnDispl4.Click += new System.EventHandler(this.btnDispl4_Click);
            this.btnDispl4.Leave += new System.EventHandler(this.btnDispl4_Leave);
            this.btnDispl4.Enter += new System.EventHandler(this.btnDispl4_Enter);
            this.btnDispl4.MouseEnter += new System.EventHandler(this.btnDispl4_MouseEnter);
            // 
            // btnDispl6
            // 
            this.btnDispl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl6.Location = new System.Drawing.Point(510, 282);
            this.btnDispl6.Name = "btnDispl6";
            this.btnDispl6.Size = new System.Drawing.Size(110, 110);
            this.btnDispl6.TabIndex = 18;
            this.btnDispl6.Text = "A";
            this.btnDispl6.UseVisualStyleBackColor = true;
            this.btnDispl6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl6_PreviewKeyDown);
            this.btnDispl6.Click += new System.EventHandler(this.btnDispl6_Click);
            this.btnDispl6.Leave += new System.EventHandler(this.btnDispl6_Leave);
            this.btnDispl6.Enter += new System.EventHandler(this.btnDispl6_Enter);
            this.btnDispl6.MouseEnter += new System.EventHandler(this.btnDispl6_MouseEnter);
            // 
            // btnDispl5
            // 
            this.btnDispl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDispl5.Location = new System.Drawing.Point(382, 282);
            this.btnDispl5.Name = "btnDispl5";
            this.btnDispl5.Size = new System.Drawing.Size(110, 110);
            this.btnDispl5.TabIndex = 17;
            this.btnDispl5.Text = "A";
            this.btnDispl5.UseVisualStyleBackColor = true;
            this.btnDispl5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnDispl5_PreviewKeyDown);
            this.btnDispl5.Click += new System.EventHandler(this.btnDispl5_Click);
            this.btnDispl5.Leave += new System.EventHandler(this.btnDispl5_Leave);
            this.btnDispl5.Enter += new System.EventHandler(this.btnDispl5_Enter);
            this.btnDispl5.MouseEnter += new System.EventHandler(this.btnDispl5_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(378, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 118);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(506, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 118);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(378, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 118);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Location = new System.Drawing.Point(505, 150);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(118, 118);
            this.panel4.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Location = new System.Drawing.Point(378, 278);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(118, 118);
            this.panel5.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Location = new System.Drawing.Point(506, 278);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(118, 118);
            this.panel6.TabIndex = 19;
            // 
            // pictBoxPanel
            // 
            this.pictBoxPanel.BackColor = System.Drawing.Color.White;
            this.pictBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictBoxPanel.Controls.Add(this.pictureBox1);
            this.pictBoxPanel.Location = new System.Drawing.Point(30, 26);
            this.pictBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pictBoxPanel.Name = "pictBoxPanel";
            this.pictBoxPanel.Size = new System.Drawing.Size(320, 300);
            this.pictBoxPanel.TabIndex = 15;
            // 
            // answerLabel
            // 
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerLabel.Location = new System.Drawing.Point(25, 342);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(332, 54);
            this.answerLabel.TabIndex = 20;
            this.answerLabel.Text = "?";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Game1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 419);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.btnDispl6);
            this.Controls.Add(this.btnDispl5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pictBoxPanel);
            this.Controls.Add(this.btnDispl4);
            this.Controls.Add(this.btnDispl3);
            this.Controls.Add(this.btnDispl2);
            this.Controls.Add(this.btnDispl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game1Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "Азбука - Найди первую букву";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDispl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDispl2;
        private System.Windows.Forms.Button btnDispl3;
        private System.Windows.Forms.Button btnDispl4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pictBoxPanel;
        private System.Windows.Forms.Button btnDispl6;
        private System.Windows.Forms.Button btnDispl5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label answerLabel;

    }
}

