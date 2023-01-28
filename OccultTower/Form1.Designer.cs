namespace OccultTower
{
    partial class Form1
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameOperator = new System.Windows.Forms.Timer(this.components);
            this.pauseTimer = new System.Windows.Forms.Timer(this.components);
            this.pauseOverlay = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.resumeButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.optionsButtonP = new System.Windows.Forms.Button();
            this.exitToMainMenuButton = new System.Windows.Forms.Button();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.startOperator = new System.Windows.Forms.Timer(this.components);
            this.menuOperator = new System.Windows.Forms.Timer(this.components);
            this.optionsOperator = new System.Windows.Forms.Timer(this.components);
            this.controlOperator = new System.Windows.Forms.Timer(this.components);
            this.ImageOverlay = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.optionButtonS = new System.Windows.Forms.Button();
            this.optionsOperatorS = new System.Windows.Forms.Timer(this.components);
            this.deathOperator = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.deathTimeLabel = new System.Windows.Forms.Label();
            this.controlOperatorP = new System.Windows.Forms.Timer(this.components);
            this.optionsOperatorM = new System.Windows.Forms.Timer(this.components);
            this.controlOperatorM = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageOverlay)).BeginInit();
            this.SuspendLayout();
            // 
            // gameOperator
            // 
            this.gameOperator.Interval = 20;
            this.gameOperator.Tick += new System.EventHandler(this.gameOperator_Tick);
            // 
            // pauseTimer
            // 
            this.pauseTimer.Interval = 20;
            this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
            // 
            // pauseOverlay
            // 
            this.pauseOverlay.BackColor = System.Drawing.Color.MidnightBlue;
            this.pauseOverlay.Location = new System.Drawing.Point(282, 108);
            this.pauseOverlay.Name = "pauseOverlay";
            this.pauseOverlay.Size = new System.Drawing.Size(100, 23);
            this.pauseOverlay.TabIndex = 0;
            this.pauseOverlay.Visible = false;
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.pauseLabel.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pauseLabel.Location = new System.Drawing.Point(124, 215);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(505, 134);
            this.pauseLabel.TabIndex = 1;
            this.pauseLabel.Text = ":PAUSE:";
            this.pauseLabel.Visible = false;
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.resumeButton.Font = new System.Drawing.Font("Castellar", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resumeButton.Location = new System.Drawing.Point(171, 422);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(458, 166);
            this.resumeButton.TabIndex = 2;
            this.resumeButton.Text = ":RESUME:";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Visible = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.restartButton.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(790, 388);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(471, 169);
            this.restartButton.TabIndex = 3;
            this.restartButton.Text = ":RESTART:";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // optionsButtonP
            // 
            this.optionsButtonP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.optionsButtonP.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButtonP.Location = new System.Drawing.Point(651, 422);
            this.optionsButtonP.Name = "optionsButtonP";
            this.optionsButtonP.Size = new System.Drawing.Size(474, 189);
            this.optionsButtonP.TabIndex = 4;
            this.optionsButtonP.Text = ":OPTIONS:";
            this.optionsButtonP.UseVisualStyleBackColor = false;
            this.optionsButtonP.Visible = false;
            this.optionsButtonP.Click += new System.EventHandler(this.optionsButtonP_Click);
            // 
            // exitToMainMenuButton
            // 
            this.exitToMainMenuButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.exitToMainMenuButton.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToMainMenuButton.Location = new System.Drawing.Point(555, 672);
            this.exitToMainMenuButton.Name = "exitToMainMenuButton";
            this.exitToMainMenuButton.Size = new System.Drawing.Size(618, 231);
            this.exitToMainMenuButton.TabIndex = 5;
            this.exitToMainMenuButton.Text = ":EXIT TO: :MAIN MENU:";
            this.exitToMainMenuButton.UseVisualStyleBackColor = false;
            this.exitToMainMenuButton.Visible = false;
            this.exitToMainMenuButton.Click += new System.EventHandler(this.exitToMainMenuButton_Click);
            // 
            // exitGameButton
            // 
            this.exitGameButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.exitGameButton.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitGameButton.Location = new System.Drawing.Point(256, 658);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(597, 219);
            this.exitGameButton.TabIndex = 6;
            this.exitGameButton.Text = ":EXIT GAME:";
            this.exitGameButton.UseVisualStyleBackColor = false;
            this.exitGameButton.Visible = false;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // startOperator
            // 
            this.startOperator.Interval = 20;
            this.startOperator.Tick += new System.EventHandler(this.startOperator_Tick);
            // 
            // menuOperator
            // 
            this.menuOperator.Interval = 20;
            this.menuOperator.Tick += new System.EventHandler(this.menuOperator_Tick);
            // 
            // optionsOperator
            // 
            this.optionsOperator.Interval = 20;
            this.optionsOperator.Tick += new System.EventHandler(this.optionsOperator_Tick);
            // 
            // controlOperator
            // 
            this.controlOperator.Interval = 20;
            this.controlOperator.Tick += new System.EventHandler(this.controlOperator_Tick);
            // 
            // ImageOverlay
            // 
            this.ImageOverlay.BackColor = System.Drawing.Color.Transparent;
            this.ImageOverlay.Location = new System.Drawing.Point(754, 120);
            this.ImageOverlay.Name = "ImageOverlay";
            this.ImageOverlay.Size = new System.Drawing.Size(100, 50);
            this.ImageOverlay.TabIndex = 7;
            this.ImageOverlay.TabStop = false;
            this.ImageOverlay.Visible = false;
            this.ImageOverlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ImageOverlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.startButton.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(890, 597);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(474, 189);
            this.startButton.TabIndex = 9;
            this.startButton.Text = ":START:";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // optionButtonS
            // 
            this.optionButtonS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.optionButtonS.Font = new System.Drawing.Font("Castellar", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionButtonS.Location = new System.Drawing.Point(725, 433);
            this.optionButtonS.Name = "optionButtonS";
            this.optionButtonS.Size = new System.Drawing.Size(474, 189);
            this.optionButtonS.TabIndex = 10;
            this.optionButtonS.Text = ":OPTIONS:";
            this.optionButtonS.UseVisualStyleBackColor = false;
            this.optionButtonS.Visible = false;
            this.optionButtonS.Click += new System.EventHandler(this.optionButtonS_Click);
            // 
            // optionsOperatorS
            // 
            this.optionsOperatorS.Interval = 20;
            this.optionsOperatorS.Tick += new System.EventHandler(this.optionsOperatorS_Tick);
            // 
            // deathOperator
            // 
            this.deathOperator.Interval = 20;
            this.deathOperator.Tick += new System.EventHandler(this.deathOperator_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(710, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 134);
            this.label1.TabIndex = 11;
            this.label1.Text = ":PAUSE:";
            this.label1.Visible = false;
            // 
            // deathTimeLabel
            // 
            this.deathTimeLabel.AutoSize = true;
            this.deathTimeLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.deathTimeLabel.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deathTimeLabel.Location = new System.Drawing.Point(251, 497);
            this.deathTimeLabel.Name = "deathTimeLabel";
            this.deathTimeLabel.Size = new System.Drawing.Size(113, 45);
            this.deathTimeLabel.TabIndex = 12;
            this.deathTimeLabel.Text = "Time";
            this.deathTimeLabel.Visible = false;
            // 
            // controlOperatorP
            // 
            this.controlOperatorP.Interval = 20;
            this.controlOperatorP.Tick += new System.EventHandler(this.controlOperatorP_Tick);
            // 
            // optionsOperatorM
            // 
            this.optionsOperatorM.Interval = 20;
            this.optionsOperatorM.Tick += new System.EventHandler(this.optionsOperatorM_Tick);
            // 
            // controlOperatorM
            // 
            this.controlOperatorM.Interval = 20;
            this.controlOperatorM.Tick += new System.EventHandler(this.controlOperatorM_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.deathTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitGameButton);
            this.Controls.Add(this.optionButtonS);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.ImageOverlay);
            this.Controls.Add(this.exitToMainMenuButton);
            this.Controls.Add(this.optionsButtonP);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.pauseOverlay);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OccultTower";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ImageOverlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameOperator;
        private System.Windows.Forms.Timer pauseTimer;
        private System.Windows.Forms.Label pauseOverlay;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button optionsButtonP;
        private System.Windows.Forms.Button exitToMainMenuButton;
        private System.Windows.Forms.Button exitGameButton;
        private System.Windows.Forms.Timer startOperator;
        private System.Windows.Forms.Timer menuOperator;
        private System.Windows.Forms.Timer optionsOperator;
        private System.Windows.Forms.Timer controlOperator;
        private System.Windows.Forms.PictureBox ImageOverlay;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button optionButtonS;
        private System.Windows.Forms.Timer optionsOperatorS;
        private System.Windows.Forms.Timer deathOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deathTimeLabel;
        private System.Windows.Forms.Timer controlOperatorP;
        private System.Windows.Forms.Timer optionsOperatorM;
        private System.Windows.Forms.Timer controlOperatorM;
    }
}

