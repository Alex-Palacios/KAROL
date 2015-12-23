namespace KAROL.Catalogos
{
    partial class RegistrarCatalogoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMARCA = new System.Windows.Forms.TextBox();
            this.txtDESCRIPCION = new System.Windows.Forms.TextBox();
            this.cbxCATEGORIA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.cbxUM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCODIGO = new System.Windows.Forms.TextBox();
            this.btnCANCELAR = new System.Windows.Forms.Button();
            this.btnGUARDAR = new System.Windows.Forms.Button();
            this.grbDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MARCA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "DESCRIPCION";
            // 
            // txtMARCA
            // 
            this.txtMARCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMARCA.Location = new System.Drawing.Point(134, 75);
            this.txtMARCA.MaxLength = 100;
            this.txtMARCA.Name = "txtMARCA";
            this.txtMARCA.Size = new System.Drawing.Size(157, 20);
            this.txtMARCA.TabIndex = 37;
            // 
            // txtDESCRIPCION
            // 
            this.txtDESCRIPCION.Location = new System.Drawing.Point(136, 112);
            this.txtDESCRIPCION.MaxLength = 255;
            this.txtDESCRIPCION.Multiline = true;
            this.txtDESCRIPCION.Name = "txtDESCRIPCION";
            this.txtDESCRIPCION.Size = new System.Drawing.Size(212, 41);
            this.txtDESCRIPCION.TabIndex = 47;
            // 
            // cbxCATEGORIA
            // 
            this.cbxCATEGORIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCATEGORIA.FormattingEnabled = true;
            this.cbxCATEGORIA.Location = new System.Drawing.Point(133, 13);
            this.cbxCATEGORIA.Name = "cbxCATEGORIA";
            this.cbxCATEGORIA.Size = new System.Drawing.Size(155, 21);
            this.cbxCATEGORIA.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "CATEGORIA";
            // 
            // grbDatosPersonales
            // 
            this.grbDatosPersonales.Controls.Add(this.cbxUM);
            this.grbDatosPersonales.Controls.Add(this.label1);
            this.grbDatosPersonales.Controls.Add(this.label23);
            this.grbDatosPersonales.Controls.Add(this.txtCODIGO);
            this.grbDatosPersonales.Controls.Add(this.cbxCATEGORIA);
            this.grbDatosPersonales.Controls.Add(this.label2);
            this.grbDatosPersonales.Controls.Add(this.label6);
            this.grbDatosPersonales.Controls.Add(this.label12);
            this.grbDatosPersonales.Controls.Add(this.txtDESCRIPCION);
            this.grbDatosPersonales.Controls.Add(this.txtMARCA);
            this.grbDatosPersonales.Location = new System.Drawing.Point(12, 4);
            this.grbDatosPersonales.Name = "grbDatosPersonales";
            this.grbDatosPersonales.Size = new System.Drawing.Size(402, 235);
            this.grbDatosPersonales.TabIndex = 67;
            this.grbDatosPersonales.TabStop = false;
            // 
            // cbxUM
            // 
            this.cbxUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUM.FormattingEnabled = true;
            this.cbxUM.Location = new System.Drawing.Point(136, 179);
            this.cbxUM.Name = "cbxUM";
            this.cbxUM.Size = new System.Drawing.Size(155, 21);
            this.cbxUM.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "UNIDAD MEDIDA";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 71;
            this.label23.Text = "ESTILO";
            // 
            // txtCODIGO
            // 
            this.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCODIGO.Location = new System.Drawing.Point(134, 40);
            this.txtCODIGO.MaxLength = 15;
            this.txtCODIGO.Name = "txtCODIGO";
            this.txtCODIGO.Size = new System.Drawing.Size(154, 20);
            this.txtCODIGO.TabIndex = 72;
            // 
            // btnCANCELAR
            // 
            this.btnCANCELAR.Image = global::KAROL.Properties.Resources.cancel_16;
            this.btnCANCELAR.Location = new System.Drawing.Point(253, 265);
            this.btnCANCELAR.Name = "btnCANCELAR";
            this.btnCANCELAR.Size = new System.Drawing.Size(128, 40);
            this.btnCANCELAR.TabIndex = 49;
            this.btnCANCELAR.Text = "CANCELAR";
            this.btnCANCELAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCANCELAR.UseVisualStyleBackColor = true;
            this.btnCANCELAR.Click += new System.EventHandler(this.CANCELAR_Click);
            // 
            // btnGUARDAR
            // 
            this.btnGUARDAR.Image = global::KAROL.Properties.Resources.icon_save;
            this.btnGUARDAR.Location = new System.Drawing.Point(58, 265);
            this.btnGUARDAR.Name = "btnGUARDAR";
            this.btnGUARDAR.Size = new System.Drawing.Size(128, 40);
            this.btnGUARDAR.TabIndex = 48;
            this.btnGUARDAR.Text = "GUARDAR";
            this.btnGUARDAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGUARDAR.UseVisualStyleBackColor = true;
            this.btnGUARDAR.Click += new System.EventHandler(this.GUARDAR_Click);
            // 
            // RegistrarCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 331);
            this.Controls.Add(this.grbDatosPersonales);
            this.Controls.Add(this.btnCANCELAR);
            this.Controls.Add(this.btnGUARDAR);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarCatalogoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRAR CATALOGO";
            this.Load += new System.EventHandler(this.RegistrarClienteForm_Load);
            this.grbDatosPersonales.ResumeLayout(false);
            this.grbDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMARCA;
        private System.Windows.Forms.TextBox txtDESCRIPCION;
        private System.Windows.Forms.Button btnGUARDAR;
        private System.Windows.Forms.Button btnCANCELAR;
        private System.Windows.Forms.ComboBox cbxCATEGORIA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbDatosPersonales;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtCODIGO;
        private System.Windows.Forms.ComboBox cbxUM;
        private System.Windows.Forms.Label label1;
    }
}