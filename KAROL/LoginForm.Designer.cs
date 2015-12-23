namespace KAROL
{
    partial class LoginForm
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
            this.txtUSER = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtPASSWORD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnEXIT = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLOGIN = new DevComponents.DotNetBar.ButtonX();
            this.dateFECHASYSTEM = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUSER
            // 
            // 
            // 
            // 
            this.txtUSER.Border.Class = "TextBoxBorder";
            this.txtUSER.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSER.Location = new System.Drawing.Point(384, 132);
            this.txtUSER.Name = "txtUSER";
            this.txtUSER.Size = new System.Drawing.Size(174, 30);
            this.txtUSER.TabIndex = 0;
            this.txtUSER.WatermarkText = "Usuario";
            this.txtUSER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUSER_KeyDown);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelX1.Location = new System.Drawing.Point(268, 132);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Size = new System.Drawing.Size(110, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "USUARIO";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelX2.Location = new System.Drawing.Point(245, 177);
            this.labelX2.Name = "labelX2";
            this.labelX2.SingleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Size = new System.Drawing.Size(133, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "PASSWORD";
            // 
            // txtPASSWORD
            // 
            // 
            // 
            // 
            this.txtPASSWORD.Border.Class = "TextBoxBorder";
            this.txtPASSWORD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPASSWORD.Location = new System.Drawing.Point(385, 177);
            this.txtPASSWORD.Name = "txtPASSWORD";
            this.txtPASSWORD.PasswordChar = '*';
            this.txtPASSWORD.Size = new System.Drawing.Size(173, 30);
            this.txtPASSWORD.TabIndex = 3;
            this.txtPASSWORD.WatermarkText = "Contraseña";
            this.txtPASSWORD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUSER_KeyDown);
            // 
            // btnEXIT
            // 
            this.btnEXIT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEXIT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEXIT.Image = global::KAROL.Properties.Resources.exit;
            this.btnEXIT.Location = new System.Drawing.Point(12, 234);
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.Size = new System.Drawing.Size(123, 43);
            this.btnEXIT.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.btnEXIT.TabIndex = 7;
            this.btnEXIT.Text = "SALIR";
            this.btnEXIT.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::KAROL.Properties.Resources.user;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(401, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 114);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KAROL.Properties.Resources.K;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 164);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnLOGIN
            // 
            this.btnLOGIN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLOGIN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLOGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOGIN.Image = global::KAROL.Properties.Resources.windows;
            this.btnLOGIN.Location = new System.Drawing.Point(401, 234);
            this.btnLOGIN.Name = "btnLOGIN";
            this.btnLOGIN.Size = new System.Drawing.Size(140, 43);
            this.btnLOGIN.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.btnLOGIN.TabIndex = 4;
            this.btnLOGIN.Text = "ENTRAR";
            this.btnLOGIN.Click += new System.EventHandler(this.btnLOGIN_Click);
            // 
            // dateFECHASYSTEM
            // 
            this.dateFECHASYSTEM.Enabled = false;
            this.dateFECHASYSTEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFECHASYSTEM.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFECHASYSTEM.Location = new System.Drawing.Point(12, 12);
            this.dateFECHASYSTEM.Name = "dateFECHASYSTEM";
            this.dateFECHASYSTEM.Size = new System.Drawing.Size(208, 26);
            this.dateFECHASYSTEM.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(585, 295);
            this.Controls.Add(this.dateFECHASYSTEM);
            this.Controls.Add(this.btnEXIT);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLOGIN);
            this.Controls.Add(this.txtPASSWORD);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtUSER);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtUSER;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPASSWORD;
        private DevComponents.DotNetBar.ButtonX btnLOGIN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.ButtonX btnEXIT;
        private System.Windows.Forms.DateTimePicker dateFECHASYSTEM;

    }
}