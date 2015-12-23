namespace KAROL.Catalogos
{
    partial class CatalogoForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tblCATALOGO = new System.Windows.Forms.DataGridView();
            this.CATEGORIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDAD_MEDIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTOTAL = new System.Windows.Forms.Label();
            this.cbxFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.cbxFiltroMarca = new System.Windows.Forms.ComboBox();
            this.txtFiltroEstilo = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.btnChangeID = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCATALOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnEditar,
            this.btnChangeID,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnExcel,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tblCATALOGO
            // 
            this.tblCATALOGO.AllowUserToAddRows = false;
            this.tblCATALOGO.AllowUserToDeleteRows = false;
            this.tblCATALOGO.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblCATALOGO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCATALOGO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CATEGORIA,
            this.COD_ITEM,
            this.MARCA,
            this.DESCRIPCION,
            this.UNIDAD_MEDIDA});
            this.tblCATALOGO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tblCATALOGO.Location = new System.Drawing.Point(12, 56);
            this.tblCATALOGO.Name = "tblCATALOGO";
            this.tblCATALOGO.ReadOnly = true;
            this.tblCATALOGO.RowHeadersVisible = false;
            this.tblCATALOGO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblCATALOGO.Size = new System.Drawing.Size(618, 301);
            this.tblCATALOGO.TabIndex = 11;
            this.tblCATALOGO.DataSourceChanged += new System.EventHandler(this.tblCATALOGO_DataSourceChanged);
            this.tblCATALOGO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCATALOGO_CellClick);
            this.tblCATALOGO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCATALOGO_CellDoubleClick);
            // 
            // CATEGORIA
            // 
            this.CATEGORIA.DataPropertyName = "CATEGORIA";
            this.CATEGORIA.HeaderText = "CATEGORIA";
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.ReadOnly = true;
            // 
            // COD_ITEM
            // 
            this.COD_ITEM.DataPropertyName = "COD_ITEM";
            this.COD_ITEM.HeaderText = "ESTILO";
            this.COD_ITEM.Name = "COD_ITEM";
            this.COD_ITEM.ReadOnly = true;
            this.COD_ITEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MARCA
            // 
            this.MARCA.DataPropertyName = "MARCA";
            this.MARCA.HeaderText = "MARCA";
            this.MARCA.Name = "MARCA";
            this.MARCA.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.DataPropertyName = "DESCRIPCION";
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 200;
            // 
            // UNIDAD_MEDIDA
            // 
            this.UNIDAD_MEDIDA.DataPropertyName = "UNIDAD_MEDIDA";
            this.UNIDAD_MEDIDA.HeaderText = "UM";
            this.UNIDAD_MEDIDA.Name = "UNIDAD_MEDIDA";
            this.UNIDAD_MEDIDA.ReadOnly = true;
            this.UNIDAD_MEDIDA.Width = 50;
            // 
            // lbTOTAL
            // 
            this.lbTOTAL.AutoSize = true;
            this.lbTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTOTAL.Location = new System.Drawing.Point(523, 33);
            this.lbTOTAL.Name = "lbTOTAL";
            this.lbTOTAL.Size = new System.Drawing.Size(70, 13);
            this.lbTOTAL.TabIndex = 12;
            this.lbTOTAL.Text = "0 ESTILOS";
            // 
            // cbxFiltroCategoria
            // 
            this.cbxFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroCategoria.FormattingEnabled = true;
            this.cbxFiltroCategoria.Location = new System.Drawing.Point(12, 33);
            this.cbxFiltroCategoria.Name = "cbxFiltroCategoria";
            this.cbxFiltroCategoria.Size = new System.Drawing.Size(100, 21);
            this.cbxFiltroCategoria.TabIndex = 15;
            this.cbxFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroCategoria_SelectedIndexChanged);
            // 
            // cbxFiltroMarca
            // 
            this.cbxFiltroMarca.FormattingEnabled = true;
            this.cbxFiltroMarca.Location = new System.Drawing.Point(216, 33);
            this.cbxFiltroMarca.Name = "cbxFiltroMarca";
            this.cbxFiltroMarca.Size = new System.Drawing.Size(100, 21);
            this.cbxFiltroMarca.TabIndex = 16;
            this.cbxFiltroMarca.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroMarca_SelectedIndexChanged);
            // 
            // txtFiltroEstilo
            // 
            this.txtFiltroEstilo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltroEstilo.Location = new System.Drawing.Point(114, 34);
            this.txtFiltroEstilo.Name = "txtFiltroEstilo";
            this.txtFiltroEstilo.Size = new System.Drawing.Size(101, 20);
            this.txtFiltroEstilo.TabIndex = 14;
            this.txtFiltroEstilo.TextChanged += new System.EventHandler(this.txtFiltroEstilo_TextChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::KAROL.Properties.Resources._new;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.ToolTipText = "Nuevo Cliente";
            this.btnNuevo.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::KAROL.Properties.Resources.gtk_edit;
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
            // btnChangeID
            // 
            this.btnChangeID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChangeID.Image = global::KAROL.Properties.Resources.llave;
            this.btnChangeID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(23, 22);
            this.btnChangeID.Text = "toolStripButton1";
            this.btnChangeID.Click += new System.EventHandler(this.btnChangeID_Click);
            // 
            // CatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(642, 359);
            this.Controls.Add(this.cbxFiltroMarca);
            this.Controls.Add(this.cbxFiltroCategoria);
            this.Controls.Add(this.txtFiltroEstilo);
            this.Controls.Add(this.tblCATALOGO);
            this.Controls.Add(this.lbTOTAL);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "CatalogoForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CATALOGO DE PRODUCTOS";
            this.Load += new System.EventHandler(this.CatalogoForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCATALOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.DataGridView tblCATALOGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MARCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDAD_MEDIDA;
        private System.Windows.Forms.Label lbTOTAL;
        private System.Windows.Forms.ComboBox cbxFiltroCategoria;
        private System.Windows.Forms.ComboBox cbxFiltroMarca;
        private System.Windows.Forms.TextBox txtFiltroEstilo;
        private System.Windows.Forms.ToolStripButton btnChangeID;
    }
}