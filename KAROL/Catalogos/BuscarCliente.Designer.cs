namespace KAROL.Catalogos
{
    partial class BuscarCliente
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdbCODIGO = new System.Windows.Forms.RadioButton();
            this.rdbNOMBRE = new System.Windows.Forms.RadioButton();
            this.rdbDOC = new System.Windows.Forms.RadioButton();
            this.txtDOC = new System.Windows.Forms.TextBox();
            this.cbmTIPODOC = new System.Windows.Forms.ComboBox();
            this.txtNOMBRE = new System.Windows.Forms.TextBox();
            this.txtCODIGO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::KAROL.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(81, 179);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 47);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdbCODIGO
            // 
            this.rdbCODIGO.AutoSize = true;
            this.rdbCODIGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCODIGO.Location = new System.Drawing.Point(12, 21);
            this.rdbCODIGO.Name = "rdbCODIGO";
            this.rdbCODIGO.Size = new System.Drawing.Size(73, 17);
            this.rdbCODIGO.TabIndex = 5;
            this.rdbCODIGO.TabStop = true;
            this.rdbCODIGO.Text = "CODIGO";
            this.rdbCODIGO.UseVisualStyleBackColor = true;
            this.rdbCODIGO.CheckedChanged += new System.EventHandler(this.rdbCODIGO_CheckedChanged);
            // 
            // rdbNOMBRE
            // 
            this.rdbNOMBRE.AutoSize = true;
            this.rdbNOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNOMBRE.Location = new System.Drawing.Point(12, 66);
            this.rdbNOMBRE.Name = "rdbNOMBRE";
            this.rdbNOMBRE.Size = new System.Drawing.Size(78, 17);
            this.rdbNOMBRE.TabIndex = 6;
            this.rdbNOMBRE.TabStop = true;
            this.rdbNOMBRE.Text = "NOMBRE";
            this.rdbNOMBRE.UseVisualStyleBackColor = true;
            this.rdbNOMBRE.CheckedChanged += new System.EventHandler(this.rdbNOMBRE_CheckedChanged);
            // 
            // rdbDOC
            // 
            this.rdbDOC.AutoSize = true;
            this.rdbDOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDOC.Location = new System.Drawing.Point(12, 108);
            this.rdbDOC.Name = "rdbDOC";
            this.rdbDOC.Size = new System.Drawing.Size(104, 17);
            this.rdbDOC.TabIndex = 7;
            this.rdbDOC.TabStop = true;
            this.rdbDOC.Text = "DOCUMENTO";
            this.rdbDOC.UseVisualStyleBackColor = true;
            this.rdbDOC.CheckedChanged += new System.EventHandler(this.rdbDOC_CheckedChanged);
            // 
            // txtDOC
            // 
            this.txtDOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDOC.Location = new System.Drawing.Point(138, 131);
            this.txtDOC.Name = "txtDOC";
            this.txtDOC.Size = new System.Drawing.Size(156, 20);
            this.txtDOC.TabIndex = 43;
            this.txtDOC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDOC_KeyDown);
            // 
            // cbmTIPODOC
            // 
            this.cbmTIPODOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmTIPODOC.FormattingEnabled = true;
            this.cbmTIPODOC.Location = new System.Drawing.Point(30, 131);
            this.cbmTIPODOC.Name = "cbmTIPODOC";
            this.cbmTIPODOC.Size = new System.Drawing.Size(102, 21);
            this.cbmTIPODOC.TabIndex = 42;
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNOMBRE.Location = new System.Drawing.Point(30, 82);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(264, 20);
            this.txtNOMBRE.TabIndex = 65;
            this.txtNOMBRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNOMBRE_KeyDown);
            // 
            // txtCODIGO
            // 
            this.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCODIGO.Location = new System.Drawing.Point(30, 40);
            this.txtCODIGO.Name = "txtCODIGO";
            this.txtCODIGO.Size = new System.Drawing.Size(117, 20);
            this.txtCODIGO.TabIndex = 66;
            this.txtCODIGO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCODIGO_KeyDown);
            // 
            // BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(304, 242);
            this.Controls.Add(this.txtCODIGO);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.txtDOC);
            this.Controls.Add(this.cbmTIPODOC);
            this.Controls.Add(this.rdbDOC);
            this.Controls.Add(this.rdbNOMBRE);
            this.Controls.Add(this.rdbCODIGO);
            this.Controls.Add(this.btnBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarCliente";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FILTRAR CLIENTES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rdbCODIGO;
        private System.Windows.Forms.RadioButton rdbNOMBRE;
        private System.Windows.Forms.RadioButton rdbDOC;
        private System.Windows.Forms.TextBox txtDOC;
        private System.Windows.Forms.ComboBox cbmTIPODOC;
        private System.Windows.Forms.TextBox txtNOMBRE;
        private System.Windows.Forms.TextBox txtCODIGO;
    }
}