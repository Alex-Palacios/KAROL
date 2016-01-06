using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAROL.Configuraciones
{
    using ControlesPersonalizados;
    using MODELO;
    using DDB;

    public partial class ConfigPreciosForm : Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static ConfigPreciosForm frmInstance = null;

        public static ConfigPreciosForm Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ConfigPreciosForm();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        //VARIABLES
        private DBKAROL dbKAROL;
        private eCategoria CATEGORIA;
        private DataTable PRECIOS;
        private DataTable FILTRO;


        public ConfigPreciosForm()
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
        }

        private void permisos()
        {
            btnGuardar.Visible = false;
            btnEditar.Visible = false;
            btnBuscar.Visible = false;
            btnExportarExcel.Visible = false;

            foreach (DataRow p in HOME.Instance().USUARIO.PERMISOS.Rows)
            {
                if (p.Field<string>("CODIGO") == "P6")
                {
                    btnGuardar.Visible = p.Field<bool>("REGISTRAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnBuscar.Visible = p.Field<bool>("BUSCAR");
                    btnExportarExcel.Visible = p.Field<bool>("BUSCAR");
                }
            }
        }

        private void ConfigPreciosForm_Load(object sender, EventArgs e)
        {
            permisos();
            tblPRECIOS.AutoGenerateColumns = false;
            CATEGORIA = eCategoria.CALZADO;
            cargarPrecios();
        }




        private void bloquear()
        {
            tblPRECIOS.ReadOnly = true;

            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }


        private void desbloquear()
        {
            tblPRECIOS.ReadOnly = false;
            tblPRECIOS.Columns["COD_ITEM"].ReadOnly = true;
            tblPRECIOS.Columns["MARCA"].ReadOnly = true;
        }




        private void cargarPrecios()
        {
            PRECIOS = dbKAROL.getPrecios(CATEGORIA);
            tblPRECIOS.DataSource = PRECIOS;
            actualizarfiltros();
            filtarDatos();
            bloquear();
        }

        

        private void actualizarfiltros()
        {
            List<string> marcas = new List<string>();
            marcas.Add("TODAS");
            txtFiltroEstilo.Text = string.Empty;
            var result = PRECIOS.AsEnumerable()
                                .Select(row => new
                                {
                                    MARCA = row.Field<string>("MARCA")
                                })
                                .Distinct().OrderBy(row => row.MARCA);
            foreach (var v in result)
            {
                marcas.Add(v.MARCA);
            }
            cbxFiltroMarca.DataSource = marcas;
        }



        private void txtFiltroEstilo_TextChanged(object sender, EventArgs e)
        {
            filtarDatos();
        }


        private void cbxFiltroMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiltroMarca.SelectedIndex >= 0)
            {
                filtarDatos();
            }
        }




        private void filtarDatos()
        {
            DataRow[] filtros;
            FILTRO = PRECIOS.Copy();
            if (FILTRO.Rows.Count > 0)
            {
                if (txtFiltroEstilo.Text.Trim() != string.Empty)
                {
                    filtros = FILTRO.Select("COD_ITEM LIKE '" + txtFiltroEstilo.Text.Trim() + "%'");
                    if (filtros.Count() > 0)
                    {
                        FILTRO = filtros.CopyToDataTable();
                    }
                    else
                    {
                        FILTRO.Clear();
                    }
                }
                if (cbxFiltroMarca.SelectedIndex > 0)
                {
                    filtros = FILTRO.Select("MARCA LIKE '" + cbxFiltroMarca.Text.Trim() + "%'");
                    if (filtros.Count() > 0)
                    {
                        FILTRO = filtros.CopyToDataTable();
                    }
                    else
                    {
                        FILTRO.Clear();
                    }
                }
            }
            tblPRECIOS.DataSource = FILTRO;
        }





        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ComboBox categorias = Controles.InputComboBox("CATEGORIA: ", "BUSCAR",Enum.GetValues(new eCategoria().GetType()));
            if (categorias != null && categorias.SelectedIndex >= 0)
            {
                CATEGORIA = (eCategoria)categorias.SelectedItem;
                cargarPrecios();

            }
        }




        private void tblPRECIOS_DataSourceChanged(object sender, EventArgs e)
        {
            if (tblPRECIOS.DataSource != null)
            {
                lbTOTAL.Text = tblPRECIOS.Rows.Count + " ESTILOS";
            }
        }





        private void btnEditar_Click(object sender, EventArgs e)
        {
            desbloquear();

            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarPrecios();
            bloquear();

            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FILTRO != null)
            {
                DataTable modificaciones = FILTRO.Clone();
                foreach (DataRow row in FILTRO.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        modificaciones.ImportRow(row);
                    }
                }
                if (modificaciones.Rows.Count > 0)
                {
                    string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                    if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                    {
                        if (dbKAROL.setPrecios(modificaciones, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            cargarPrecios();
                        }
                    }
                    else
                    {
                        MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    
                }
                else
                {
                    MessageBox.Show("NO SE HAN MODIFICADO PRECIOS", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("PRECIOS NO LISTADOS", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (FILTRO != null)
            {
                HOME.Instance().exportDataGridViewToExcel("LISTA DE PRECIOS", tblPRECIOS.Columns, FILTRO, "ListaPrecios");
            }
        }




        private void tblPRECIOS_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (tblPRECIOS.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Red, 1))
                    {
                        Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                    e.Handled = true;
                }
            }
        }



        private void tblITEMS_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = tblPRECIOS.Columns[e.ColumnIndex].Name;
            switch (columnName)
            {
                case "PRECIO":
                    // Verificar si columna esta vacia
                    if (e.FormattedValue != null)
                    {
                        decimal valor;

                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Columna MONTO Vacia";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (!Decimal.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Currency, null, out valor))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Formato Invalido";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (valor < 0)
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "PRECIO debe ser mayor o igual a 0";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                    }
                    break;
                case "DESCUENTO":
                    // Verificar si columna esta vacia
                    if (e.FormattedValue != null)
                    {
                        decimal valor = 0;
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Columna DESCUENTO Vacia";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (!Decimal.TryParse(e.FormattedValue.ToString().Replace('%',' ').Trim(), System.Globalization.NumberStyles.Currency, null, out valor))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Formato Invalido";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (valor < 0)
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "DESCUENTO debe ser mayor i igual a 0";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }

                    }
                    break;
                case "LIQUIDACION":
                    // Verificar si columna esta vacia
                    if (e.FormattedValue != null)
                    {
                        decimal valor;

                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Columna LIQUIDACION Vacia";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (!Decimal.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Currency, null, out valor))
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "Formato Invalido";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (valor < 0)
                        {
                            tblPRECIOS.Rows[e.RowIndex].ErrorText = "LIQUIDACION debe ser mayor o igual a 0";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                    }
                    break;
            }
        }



        private void tblPRECIOS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tblPRECIOS.Rows[e.RowIndex].ErrorText = String.Empty;
            if (e.RowIndex >= 0)
            {
                decimal precio = Decimal.Parse(tblPRECIOS.Rows[e.RowIndex].Cells["PRECIO"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                decimal descuento = Decimal.Parse(tblPRECIOS.Rows[e.RowIndex].Cells["DESCUENTO"].Value.ToString().Replace('%', ' ').Trim(), System.Globalization.NumberStyles.Currency);
                decimal liquidacion = Decimal.Parse(tblPRECIOS.Rows[e.RowIndex].Cells["LIQUIDACION"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                
                string columnName = tblPRECIOS.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "DESCUENTO":
                        tblPRECIOS.Rows[e.RowIndex].Cells["DESCUENTO"].Value = Decimal.Round(descuento / 100,2,MidpointRounding.AwayFromZero);
                        break;
                }

                
            }
        }






    }
}
