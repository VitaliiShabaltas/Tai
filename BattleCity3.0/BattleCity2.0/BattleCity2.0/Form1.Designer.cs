namespace BattleCity2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtScore = new Label();
            HeLTH = new Label();
            healthBar = new ProgressBar();
            Player = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtScore.ForeColor = Color.White;
            txtScore.Location = new Point(483, 12);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(85, 31);
            txtScore.TabIndex = 0;
            txtScore.Text = "Kills: 0";
            // 
            // HeLTH
            // 
            HeLTH.AutoSize = true;
            HeLTH.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            HeLTH.ForeColor = Color.White;
            HeLTH.Location = new Point(868, 9);
            HeLTH.Name = "HeLTH";
            HeLTH.Size = new Size(86, 31);
            HeLTH.TabIndex = 1;
            HeLTH.Text = "Health";
            // 
            // healthBar
            // 
            healthBar.Location = new Point(960, 12);
            healthBar.Name = "healthBar";
            healthBar.Size = new Size(210, 29);
            healthBar.TabIndex = 2;
            // 
            // Player
            // 
            Player.Image = Properties.Resources.pup;
            Player.Location = new Point(573, 652);
            Player.Name = "Player";
            Player.Size = new Size(42, 47);
            Player.SizeMode = PictureBoxSizeMode.AutoSize;
            Player.TabIndex = 3;
            Player.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += MainTimerEvent;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(396, 310);
            label1.Name = "label1";
            label1.Size = new Size(403, 115);
            label1.TabIndex = 0;
            label1.Text = "Програш";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(396, 310);
            label2.Name = "label2";
            label2.Size = new Size(453, 115);
            label2.TabIndex = 4;
            label2.Text = "Перемога";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1182, 753);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Player);
            Controls.Add(healthBar);
            Controls.Add(HeLTH);
            Controls.Add(txtScore);
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtScore;
        private Label HeLTH;
        private ProgressBar healthBar;
        private PictureBox Player;
        private System.Windows.Forms.Timer GameTimer;
        private Label label1;
        private Label label2;
    }
}
