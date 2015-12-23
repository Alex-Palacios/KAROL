using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAROL.Transacciones
{
    using MODELO;
    using DDB;

    public partial class IngresoDetalleForm : Form
    {
        private eCategoria CATEGORIA;
        private DBCatalogo dbCatalogo;
        private DataTable ITEMS;
        private decimal MONTO;
        private int CAJAS;

        public IngresoDetalleForm(eCategoria categoria)
        {
            InitializeComponent();
            dbCatalogo = new DBCatalogo();
            this.CATEGORIA = categoria;
            ITEMS = new DataTable();
            ITEMS.Columns.Add("COLOR").DataType = System.Type.GetType("System.String");
            ITEMS.Columns.Add("T1").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T2").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T3").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T4").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T5").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T6").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T7").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T8").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T9").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T10").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T11").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T12").DataType = System.Type.GetType("System.Int32");
            ITEMS.Columns.Add("T13").DataType = System.Type.GetType("System.Int32");
        }


        private void IngresoDetalleForm_Load(object sender, EventArgs e)
        {
            tblDETALLE.AutoGenerateColumns = false;
            this.Text = "DETALLE " + this.CATEGORIA.ToString();
            cbxCORRIDA.DataSource = Enum.GetValues(new eCorridaCalzado().GetType());
            cbxCOMO.DataSource = Enum.GetValues(new eIngresarComo().GetType());
            cbxESTILO.DataSource = dbCatalogo.showCatalogo(this.CATEGORIA);
            if (((DataTable)cbxESTILO.DataSource).Rows.Count > 0)
            {
                cbxESTILO.DisplayMembers = "COD_ITEM";
                cbxESTILO.ValueMember = "COD_ITEM";
                cbxESTILO.SelectedIndex = 0;
            }
            limpiar();
            tblDETALLE.DataSource = ITEMS;
        }




        private void limpiar()
        {
            ITEMS.Clear();
            lbTOTAL.Text = "0";
            MONTO = 0;
            CAJAS = 0;
            txtMONTO.Text = MONTO.ToString("C2");
        }



        private void cbxESTILO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxESTILO.SelectedIndex >= 0)
            {
                limpiar();
            }
        }



        private void cbxCORRIDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCORRIDA.SelectedIndex >= 0)
            {
                for (int c = 1; c <= 13; c++)
                {
                    switch ((eCorridaCalzado)cbxCORRIDA.SelectedItem)
                    {
                        case eCorridaCalzado.A:
                            tblDETALLE.Columns[c].HeaderText = HOME.Instance().CalzadoA[c - 1];
                            break;
                        case eCorridaCalzado.B:
                            tblDETALLE.Columns[c].HeaderText = HOME.Instance().CalzadoB[c - 1];
                            break;
                        case eCorridaCalzado.C:
                            tblDETALLE.Columns[c].HeaderText = HOME.Instance().CalzadoC[c - 1];
                            break;
                    }
                }

            }
        }

        private void cbxCOMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCOMO.SelectedIndex >= 0)
            {
                switch ((eIngresarComo)cbxCOMO.SelectedItem)
                {
                    case eIngresarComo.CAJA:
                        numCajas.Minimum = 1;
                        numCajas.Value = 1;
                        numCajas.Enabled = true;
                        break;
                    case eIngresarComo.UNITARIO:
                        numCajas.Minimum = 0;
                        numCajas.Value = 0;
                        numCajas.Enabled = false;
                        break;
                }
            }
        }


        private void calcularTotales()
        {
            int unidades = 0;
            foreach (DataRow row in ITEMS.Rows)
            {
                unidades = unidades + row.Field<int>("T1") + row.Field<int>("T2") + row.Field<int>("T3") + row.Field<int>("T4") + row.Field<int>("T5") + row.Field<int>("T6") + row.Field<int>("T7") + row.Field<int>("T8") + row.Field<int>("T9") + row.Field<int>("T10") + row.Field<int>("T11") + row.Field<int>("T12") + row.Field<int>("T13");
            }
            lbTOTAL.Text = "" + unidades;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow nuevo = ITEMS.Rows.Add("",0,0,0,0,0,0,0,0,0,0,0,0,0);
            tblDETALLE.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ITEMS.Rows.Count > 0)
            {
                ITEMS.Rows.RemoveAt(tblDETALLE.CurrentCell.RowIndex);
            }
        }



        private void tblDETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = e.Value.ToString().ToUpper();
                        break;
                    default:
                        int x = (int)e.Value;
                        if (x == 0)
                        {
                            e.Value = "";
                        }
                        break;
                }
                
            }
            catch (Exception ex)
            {

            }
        }




        private void tblDETALLE_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = tblDETALLE.Columns[e.ColumnIndex].Name;
            switch (columnName)
            {
                case "COLOR":
                    // Verificar si columna esta vacia
                    if (e.FormattedValue != null)
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            tblDETALLE.Rows[e.RowIndex].ErrorText = "Color Invalido";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                    }
                    break;
                default:
                    // Verificar si columna esta vacia
                    if (e.FormattedValue != null)
                    {
                        int valor;

                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            //tblDETALLE.Rows[e.RowIndex].ErrorText = "Cantidad Invalida";
                            //System.Media.SystemSounds.Beep.Play();
                            //e.Cancel = true;
                        }
                        else if (!Int32.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Currency, null, out valor))
                        {
                            tblDETALLE.Rows[e.RowIndex].ErrorText = "Formato Invalido";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                        else if (valor < 0)
                        {
                            tblDETALLE.Rows[e.RowIndex].ErrorText = "Cantidad debe ser mayor o igual a 0";
                            System.Media.SystemSounds.Beep.Play();
                            e.Cancel = true;
                        }
                    }
                    break;
            }
        }

        


        private void tblITEMS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tblDETALLE.Rows[e.RowIndex].ErrorText = String.Empty;
            if (e.RowIndex >= 0)
            {
                string columnName = tblDETALLE.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "COLOR":
                       
                        break;
                    default:
                        calcularTotales();
                        break;
                }
            }
        }




        private bool validar()
        {
            bool OK = true;

            return OK;
        }

        private bool validarItems()
        {
            bool OK = true;
            if (tblDETALLE.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tblDETALLE.Rows)
                {
                    if (row.Cells["COLOR"].Value == null || row.Cells["COLOR"].Value == string.Empty)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("ESPECIFIQUE COLOR", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T1"].Value == null || Int32.Parse(row.Cells["T1"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T2"].Value == null || Int32.Parse(row.Cells["T2"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T3"].Value == null || Int32.Parse(row.Cells["T3"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T4"].Value == null || Int32.Parse(row.Cells["T4"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T5"].Value == null || Int32.Parse(row.Cells["T5"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T6"].Value == null || Int32.Parse(row.Cells["T6"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T7"].Value == null || Int32.Parse(row.Cells["T7"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T8"].Value == null || Int32.Parse(row.Cells["T8"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T9"].Value == null || Int32.Parse(row.Cells["T9"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T10"].Value == null || Int32.Parse(row.Cells["T10"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T11"].Value == null || Int32.Parse(row.Cells["T11"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T12"].Value == null || Int32.Parse(row.Cells["T12"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["T13"].Value == null || Int32.Parse(row.Cells["T13"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblDETALLE.CurrentRow.Selected = false;
                        tblDETALLE.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            else
            {
                OK = false;
                MessageBox.Show("DETALLE VACIO", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return OK;
        }





        private void btnLISTAR_Click(object sender, EventArgs e)
        {
            if (validar())
            {

            }
        }





    }
}
