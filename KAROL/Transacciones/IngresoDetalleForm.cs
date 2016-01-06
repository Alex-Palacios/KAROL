﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlesPersonalizados;

namespace KAROL.Transacciones
{
    using MODELO;
    using DDB;

    public partial class IngresoDetalleForm : Form
    {
        private eCategoria CATEGORIA;
        private eOperacion ACCION;
        private DBCatalogo dbCatalogo;
        private DBInventario dbInventario;
        private DBCompra dbCompra;
        private Preingreso PREINGRESO;

        public IngresoDetalleForm(eOperacion accion,eCategoria categoria)
        {
            InitializeComponent();
            dbCatalogo = new DBCatalogo();
            dbCompra = new DBCompra();
            dbInventario = new DBInventario();
            PREINGRESO = new Preingreso();
            this.CATEGORIA = categoria;
            this.ACCION = accion;
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
            tblDETALLE.DataSource = PREINGRESO.ITEMS;
        }




        private void limpiar()
        {
            PREINGRESO.ITEMS.Clear();
            PREINGRESO.MONTO = (decimal)0.00;
            PREINGRESO.CAJAS = 0;
            PREINGRESO.UNIDADES = 0;
            
            lbTOTAL.Text = "" + PREINGRESO.UNIDADES;
            txtMONTO.Text = PREINGRESO.MONTO.ToString("C2");
            calcularTotales();
        }



        private void cbxESTILO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxESTILO.SelectedIndex >= 0)
            {
                PREINGRESO.ESTILO = (string)cbxESTILO.SelectedValue;
                limpiar();
            }
        }



        private void cbxCORRIDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCORRIDA.SelectedIndex >= 0)
            {
                PREINGRESO.CORRIDA = (eCorridaCalzado)cbxCORRIDA.SelectedItem;
                for (int c = 1; c <= 13; c++)
                {
                    switch (PREINGRESO.CORRIDA)
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
                PREINGRESO.COMO = (eIngresarComo)cbxCOMO.SelectedItem;
                switch (PREINGRESO.COMO)
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
            PREINGRESO.UNIDADES=0;

            foreach (DataRow row in PREINGRESO.ITEMS.Rows)
            {
                PREINGRESO.UNIDADES = PREINGRESO.UNIDADES + row.Field<int>("T1") + row.Field<int>("T2") + row.Field<int>("T3") + row.Field<int>("T4") +
                        row.Field<int>("T5") + row.Field<int>("T6") + row.Field<int>("T7") + row.Field<int>("T8") + row.Field<int>("T9") + row.Field<int>("T10") + row.Field<int>("T11") + row.Field<int>("T12") + row.Field<int>("T13");
            }
            lbTOTAL.Text = PREINGRESO.UNIDADES.ToString("N0");
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow nuevo = PREINGRESO.ITEMS.Rows.Add("",0,0,0,0,0,0,0,0,0,0,0,0,0);
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (PREINGRESO.ITEMS.Rows.Count > 0)
            {
                PREINGRESO.ITEMS.Rows.RemoveAt(tblDETALLE.CurrentCell.RowIndex);
            }
        }






        private void tblDETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = tblDETALLE.Columns[e.ColumnIndex].Name;
            switch (columnName)
            {
                case "COLOR":
                    e.Value = e.Value.ToString().ToUpper();
                    break;
                default:
                    if (e.Value != DBNull.Value)
                    {
                        int x = (int)e.Value;
                        if (x == 0)
                        {
                            e.Value = string.Empty;
                        }
                    }
                    break;
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
                            //tblDETALLE.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                            //ITEMS.Rows[e.RowIndex].SetField<int>(columnName, 0);
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
                        PREINGRESO.ITEMS.Rows[e.RowIndex].SetField<string>(columnName, tblDETALLE.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString());
                        break;
                    default:
                        if (string.IsNullOrEmpty(tblDETALLE.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString()))
                        {
                            tblDETALLE.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                            PREINGRESO.ITEMS.Rows[e.RowIndex].SetField<int>(columnName, 0);
                        }
                        calcularTotales();
                        break;
                }
            }
        }




        private bool validar()
        {
            bool OK = true;
            try
            {
                if (PREINGRESO.MONTO <= (decimal)0)
                {
                    OK = false;
                    MessageBox.Show("MONTO DEBE SER MAYOR A CERO", "ERROR DE VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                validarItems();
            }
            catch (Exception ex)
            {
                OK = false;
            }
            return OK;
        }




        private bool validarItems()
        {
            bool OK = true;
            if (tblDETALLE.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tblDETALLE.Rows)
                {
                    
                }
            }
            else
            {
                OK = false;
                MessageBox.Show("DETALLE VACIO", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return OK;
        }





        private void txtMONTO_Leave(object sender, EventArgs e)
        {
            PREINGRESO.MONTO = (decimal)0.00;
            decimal valor;
            if (Decimal.TryParse(txtMONTO.Text, System.Globalization.NumberStyles.Currency, null, out valor))
            {
                PREINGRESO.MONTO = Decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                MessageBox.Show("FORMATO INVALIDO", "ERROR DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtMONTO.Text = PREINGRESO.MONTO.ToString("C2");
        }






        private void btnLISTAR_Click(object sender, EventArgs e)
        {
            PREINGRESO.CRUD = ACCION;
            PREINGRESO.CATEGORIA = CATEGORIA;
            PREINGRESO.CAJAS = (int)numCajas.Value;
            PREINGRESO.ESTILO = (string)cbxESTILO.SelectedValue;
            if (validar())
            {
                switch (PREINGRESO.COMO)
                {
                    case eIngresarComo.CAJA:
                        for (int c = 1; c <= PREINGRESO.CAJAS; c++)
                        {
                            string codigo = string.Empty;
                            while (codigo == null || codigo.Trim() == string.Empty)
                            {
                                codigo = Controles.InputBox("CODIGO", "CODIGO DE BULTO");
                            }
                            PREINGRESO.CODIGO = codigo;
                            dbInventario.insertPREINGRESO(PREINGRESO, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA);
                        }
                        ComprasForm.Instance().cargarPreingreso();
                        this.Close();
                        break;
                    case eIngresarComo.UNITARIO:
                        if (dbInventario.insertPREINGRESO(PREINGRESO, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA)) ;
                        {
                            ComprasForm.Instance().cargarPreingreso();
                            this.Close();
                        }
                        break;
                }
                
            }
        }




       


        

    }
}
