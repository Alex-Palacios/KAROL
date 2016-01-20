﻿namespace KAROL.Catalogos
{
    partial class ProveedoresForm
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
            this.tblPROVEEDORES = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.lbNUM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.COD_PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NATURALEZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblPROVEEDORES)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPROVEEDORES
            // 
            this.tblPROVEEDORES.AllowUserToAddRows = false;
            this.tblPROVEEDORES.AllowUserToDeleteRows = false;
            this.tblPROVEEDORES.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblPROVEEDORES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPROVEEDORES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COD_PROVEEDOR,
            this.NATURALEZA,
            this.NOMBRE,
            this.DUI,
            this.NIT,
            this.NRC,
            this.TEL,
            this.PAIS});
            this.tblPROVEEDORES.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tblPROVEEDORES.Location = new System.Drawing.Point(0, 28);
            this.tblPROVEEDORES.Name = "tblPROVEEDORES";
            this.tblPROVEEDORES.ReadOnly = true;
            this.tblPROVEEDORES.RowHeadersVisible = false;
            this.tblPROVEEDORES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblPROVEEDORES.Size = new System.Drawing.Size(939, 270);
            this.tblPROVEEDORES.TabIndex = 0;
            this.tblPROVEEDORES.DataSourceChanged += new System.EventHandler(this.tblPROVEEDORES_DataSourceChanged);
            this.tblPROVEEDORES.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblPROVEEDORES_CellClick);
            this.tblPROVEEDORES.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblPROVEEDORES_CellDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnBuscar,
            this.btnExcel,
            this.btnLog,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(949, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::KAROL.Properties.Resources.nuevo;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.ToolTipText = "Nuevo Cliente";
            this.btnNuevo.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::KAROL.Properties.Resources.edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.ToolTipText = "Editar Informacion Cliente";
            this.btnEditar.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::KAROL.Properties.Resources.eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.ToolTipText = "Eliminar Cliente";
            this.btnEliminar.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = global::KAROL.Properties.Resources.buscar_icon2;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(23, 22);
            this.btnBuscar.ToolTipText = "Buscar o Filtrar";
            this.btnBuscar.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcel.Image = global::KAROL.Properties.Resources.ico_excel;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExcel.Text = "Exportar a Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnLog
            // 
            this.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLog.Image = global::KAROL.Properties.Resources.log;
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(23, 22);
            this.btnLog.ToolTipText = "Ver Log de Transacciones";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::KAROL.Properties.Resources.help;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.ToolTipText = "Mostrar Ayuda";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lbNUM
            // 
            this.lbNUM.AutoSize = true;
            this.lbNUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNUM.Location = new System.Drawing.Point(863, 301);
            this.lbNUM.Name = "lbNUM";
            this.lbNUM.Size = new System.Drawing.Size(14, 13);
            this.lbNUM.TabIndex = 7;
            this.lbNUM.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(733, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "COINCIDENCIAS";
            // 
            // COD_PROVEEDOR
            // 
            this.COD_PROVEEDOR.DataPropertyName = "COD_PROVEEDOR";
            this.COD_PROVEEDOR.HeaderText = "CODIGO";
            this.COD_PROVEEDOR.Name = "COD_PROVEEDOR";
            this.COD_PROVEEDOR.ReadOnly = true;
            this.COD_PROVEEDOR.Width = 80;
            // 
            // NATURALEZA
            // 
            this.NATURALEZA.DataPropertyName = "NATURALEZA";
            this.NATURALEZA.HeaderText = "PERSONA";
            this.NATURALEZA.Name = "NATURALEZA";
            this.NATURALEZA.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "CLIENTE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 250;
            // 
            // DUI
            // 
            this.DUI.DataPropertyName = "DUI";
            this.DUI.HeaderText = "DUI";
            this.DUI.Name = "DUI";
            this.DUI.ReadOnly = true;
            // 
            // NIT
            // 
            this.NIT.DataPropertyName = "NIT";
            this.NIT.HeaderText = "NIT";
            this.NIT.Name = "NIT";
            this.NIT.ReadOnly = true;
            // 
            // NRC
            // 
            this.NRC.DataPropertyName = "NRC";
            this.NRC.HeaderText = "NRC";
            this.NRC.Name = "NRC";
            this.NRC.ReadOnly = true;
            this.NRC.Width = 80;
            // 
            // TEL
            // 
            this.TEL.DataPropertyName = "TEL";
            this.TEL.HeaderText = "TEL";
            this.TEL.Name = "TEL";
            this.TEL.ReadOnly = true;
            this.TEL.Width = 80;
            // 
            // PAIS
            // 
            this.PAIS.DataPropertyName = "PAIS";
            this.PAIS.HeaderText = "PAIS";
            this.PAIS.Name = "PAIS";
            this.PAIS.ReadOnly = true;
            // 
            // ProveedoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(949, 321);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNUM);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tblPROVEEDORES);
            this.MaximizeBox = false;
            this.Name = "ProveedoresForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CARTERA DE CLIENTES";
            this.Load += new System.EventHandler(this.ProveedoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPROVEEDORES)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblPROVEEDORES;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.Label lbNUM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NATURALEZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAIS;
    }
}