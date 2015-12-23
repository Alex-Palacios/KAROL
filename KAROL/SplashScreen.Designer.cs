namespace KAROL
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.statusLabel = new System.Windows.Forms.StatusStrip();
            this.progressText = new System.Windows.Forms.ToolStripStatusLabel();
            this.progreso = new System.Windows.Forms.ProgressBar();
            this.background = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.statusLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.White;
            this.statusLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressText});
            this.statusLabel.Location = new System.Drawing.Point(0, 238);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(674, 22);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "statusStrip1";
            // 
            // progressText
            // 
            this.progressText.BackColor = System.Drawing.Color.White;
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(62, 17);
            this.progressText.Text = "Loading ...";
            // 
            // progreso
            // 
            this.progreso.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.progreso.BackColor = System.Drawing.Color.SeaShell;
            this.progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progreso.ForeColor = System.Drawing.Color.Firebrick;
            this.progreso.Location = new System.Drawing.Point(0, 217);
            this.progreso.Name = "progreso";
            this.progreso.Size = new System.Drawing.Size(674, 21);
            this.progreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progreso.TabIndex = 5;
            // 
            // background
            // 
            this.background.WorkerReportsProgress = true;
            this.background.WorkerSupportsCancellation = true;
            this.background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tareaBackground);
            this.background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progresoTarea);
            this.background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tareaCompletada);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(202, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "GRUPO D\'DICARK S.A de C.V";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KAROL.Properties.Resources.tacon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(471, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 137);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::KAROL.Properties.Resources.KAROL;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logo.InitialImage = null;
            this.logo.Location = new System.Drawing.Point(29, 23);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(356, 137);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(674, 260);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progreso);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.statusLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.Opacity = 0.9D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.statusLabel.ResumeLayout(false);
            this.statusLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusLabel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.ProgressBar progreso;
        private System.ComponentModel.BackgroundWorker background;
        public System.Windows.Forms.ToolStripStatusLabel progressText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}