using System;
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

    public partial class ComprasForm : Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static ComprasForm frmInstance = null;

        public static ComprasForm Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ComprasForm();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        //VARIABLES
        private DBKAROL dbKAROL;
        private DBProveedor dbProveedor;
        private DBInventario dbInventario;
        private DBCompra dbCompra;

        private eOperacion ACCION;

        private Compra COMPRA;
        private Compra SELECTED;

        public ComprasForm()
        {
            InitializeComponent();
            this.tblITEMS_CALZADO.InitColumnTable("COMPRA");
            dbKAROL = new DBKAROL();
            dbProveedor = new DBProveedor();
            dbInventario = new DBInventario();
            dbCompra = new DBCompra();
        }



        private void permisos()
        {
            btnNuevo.Visible = false;
            btnGuardar.Visible = false;
            btnEditar.Visible = false;
            btnAnular.Visible = false;
            btnEliminar.Visible = false;
            btnBuscar.Visible = false;
            btnLog.Visible = false;

            foreach (DataRow p in HOME.Instance().USUARIO.PERMISOS.Rows)
            {
                if (p.Field<string>("CODIGO") == "P4")
                {
                    btnNuevo.Visible = p.Field<bool>("REGISTRAR");
                    btnGuardar.Visible = p.Field<bool>("REGISTRAR") || p.Field<bool>("ACTUALIZAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnAnular.Visible = p.Field<bool>("ANULAR");
                    btnEliminar.Visible = p.Field<bool>("ELIMINAR");
                    btnBuscar.Visible = p.Field<bool>("BUSCAR");
                    btnLog.Visible = p.Field<bool>("LOG");
                }
            }

            if (HOME.Instance().USUARIO.TIPO == eTipoUsuario.BODEGA || HOME.Instance().USUARIO.TIPO == eTipoUsuario.VENDEDOR)
            {
                cbxSUCURSAL.Enabled = false;
            }
            else
            {
                cbxSUCURSAL.Enabled = true;
            }
        }

        

        private void ComprasForm_Load(object sender, EventArgs e)
        {
            permisos();
            tblITEMS_CALZADO.AutoGenerateColumns = false;
            cbxPersonaPRO.DataSource = Enum.GetValues(new eNaturalezaPersona().GetType());
            cbxSUCURSAL.DataSource = HOME.Instance().datSUCURSALES.Copy();
            if (HOME.Instance().datSUCURSALES.Rows.Count > 0)
            {
                cbxSUCURSAL.DisplayMember = "SUCURSAL";
                cbxSUCURSAL.ValueMember = "COD_SUC";
                cbxSUCURSAL.SelectedValue = HOME.Instance().SUCURSAL.COD_SUC;
            }

            bloquear();
            NUEVO(null, null);
        }


        private void bloquear()
        {
            grbCOMPRA.Enabled = false;
            tabDETALLE.Enabled = false;
            txtAJUSTE.ReadOnly = true;
        }


        private void desbloquear()
        {
            grbCOMPRA.Enabled = true;
            tabDETALLE.Enabled = true;
            txtAJUSTE.ReadOnly = false;
        }


        private void limpiarDatosProveedor()
        {
            txtCodigoPRO.Text = string.Empty;
            cbxPersonaPRO.Text = string.Empty;
            txtNombrePRO.Text = string.Empty;
            txtTelPRO.Text = string.Empty;
        }



        private void limpiarDatosCompra()
        {

            txtDOCUMENTO.Text = string.Empty;
            tblITEMS_CALZADO.DataSource = null;
            txtTOTAL.Text = string.Empty;
            txtNOTA.Text = string.Empty;
            txtAJUSTE.Text = string.Empty;
        }


        public void cargarPreingreso()
        {
            COMPRA.ITEMS_COMPRA = dbInventario.getPREINGRESO(ACCION, HOME.Instance().USUARIO.COD_EMPLEADO);
            refreshPreingreso();
        }




        public void refreshPreingreso()
        {
            tblITEMS_CALZADO.DataSource = COMPRA.ITEMS_COMPRA;
            calcularTotales();
        }




        private void NUEVO(object sender, EventArgs e)
        {
            ACCION = eOperacion.INSERT;
            COMPRA = new Compra();
            COMPRA.COD_SUC = HOME.Instance().SUCURSAL.COD_SUC;
            COMPRA.FECHA = HOME.Instance().FECHA_SISTEMA;
            COMPRA.TIPO = eTipoCompra.IMPORTADO;
            cargarPreingreso();
            cargarDatosProveedor(null);
            cargarDatosCompra();

            desbloquear();
            txtDOCUMENTO.Focus();

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLog.Enabled = false;

        }






        public void cargarDatosProveedor(Proveedor PROVEEDOR)
        {
            if (PROVEEDOR != null && PROVEEDOR.COD_PROVEEDOR != null && PROVEEDOR.COD_PROVEEDOR != string.Empty)
            {
                COMPRA.COD_PROVEEDOR = PROVEEDOR.COD_PROVEEDOR;
                COMPRA.PERSONA = PROVEEDOR.NATURALEZA;
                COMPRA.PROVEEDOR = PROVEEDOR.NOMBRE;
                COMPRA.TELEFONO = PROVEEDOR.TEL;
               
            }

            txtCodigoPRO.Text = COMPRA.COD_PROVEEDOR;
            cbxPersonaPRO.SelectedItem = COMPRA.PERSONA; 
            txtNombrePRO.Text = COMPRA.PROVEEDOR;
            txtTelPRO.Text = COMPRA.TELEFONO;

        }




        private void cargarDatosCompra()
        {
            if (COMPRA != null)
            {
                cbxSUCURSAL.SelectedValue = COMPRA.COD_SUC;
                txtDOCUMENTO.Text = COMPRA.DOCUMENTO;
                dateCompra.Value = COMPRA.FECHA;
                switch (COMPRA.TIPO)
                {
                    case eTipoCompra.NACIONAL:
                        rdbNacional.Checked = true;
                        break;
                    case eTipoCompra.IMPORTADO:
                        rdbImportado.Checked = true;
                        break;
                }
                tblITEMS_CALZADO.DataSource = null;
                switch (COMPRA.CATEGORIA)
                {
                    case eCategoria.CALZADO:
                        tabDETALLE.SelectedTab = pagCALZADO;
                        break;
                    case eCategoria.CARTERA:
                        tabDETALLE.SelectedTab = pagCARTERA;
                        break;
                    case eCategoria.ROPA:
                        tabDETALLE.SelectedTab = pagROPA;
                        break;
                    case eCategoria.MOCHILA:
                        tabDETALLE.SelectedTab = pagMOCHILA;
                        break;
                }
                tblITEMS_CALZADO.DataSource = COMPRA.ITEMS_COMPRA;
                txtAJUSTE.Text = COMPRA.AJUSTE.ToString("C2"); 
                txtTOTAL.Text = COMPRA.TOTAL.ToString("C2");
                txtNOTA.Text = COMPRA.NOTA;
            }
            else
            {
                limpiarDatosCompra();
            }
        }


        private void btnPRO_Click(object sender, EventArgs e)
        {
            Catalogos.ProveedoresForm cartera;
            cartera = Catalogos.ProveedoresForm.Instance(this.Name);
            cartera.StartPosition = FormStartPosition.CenterParent;
            cartera.ShowDialog(this);
            if (cartera.WindowState == FormWindowState.Minimized)
            {
                cartera.WindowState = FormWindowState.Normal;
            }
        }


        private void calcularTotales()
        {
            COMPRA.UNIDADES = COMPRA.ITEMS_COMPRA.AsEnumerable().Select(r => Int32.Parse(r.Field<object>("UNIDADES").ToString())).Sum();
            COMPRA.MONTO = COMPRA.ITEMS_COMPRA.AsEnumerable().Select(r => r.Field<decimal>("MONTO")).Sum();
            COMPRA.TOTAL = COMPRA.MONTO + COMPRA.AJUSTE;

            lbTOTAL_UNIDADES.Text = COMPRA.UNIDADES.ToString("N0");
            lbTOTAL_MONTO.Text = COMPRA.MONTO.ToString("C2");
            txtAJUSTE.Text = COMPRA.AJUSTE.ToString("C2");
            txtTOTAL.Text = COMPRA.TOTAL.ToString("C2");
        }



        private void cbxSUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSUCURSAL.ValueMember != "" && cbxSUCURSAL.SelectedIndex >= 0)
            {
                switch (ACCION)
                {
                    case eOperacion.INSERT:
                        COMPRA.COD_SUC = (string)cbxSUCURSAL.SelectedValue;
                        txtDOCUMENTO.Text = COMPRA.DOCUMENTO;
                        break;

                }
            }
        }




        private void rdbImportado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImportado.Checked)
            {
                COMPRA.TIPO = eTipoCompra.IMPORTADO;
            }
        }



        private void rdbNacional_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNacional.Checked)
            {
                COMPRA.TIPO = eTipoCompra.NACIONAL;
            }

        }




        private void btnAddItem_Click(object sender, EventArgs e)
        {
            IngresoDetalleForm nuevo = new IngresoDetalleForm(ACCION,eCategoria.CALZADO);
            nuevo.ShowDialog(this);
        }





        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (tblITEMS_CALZADO.CurrentCell != null && tblITEMS_CALZADO.CurrentCell.RowIndex >=0)
            {
                if (dbInventario.deletePREINGRESO(COMPRA.ITEMS_COMPRA.Rows[tblITEMS_CALZADO.CurrentCell.RowIndex].Field<int>("ID"), HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                {
                    cargarPreingreso();
                }
                
            }
        }





        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            DialogResult clean = MessageBox.Show("¿Limpiar preingreso?", "LIMPIAR DETALLE PREINGRESO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clean == DialogResult.Yes)
            {
                if (dbInventario.limpiarPREINGRESO(ACCION, HOME.Instance().USUARIO.COD_EMPLEADO))
                {
                    cargarPreingreso();
                }
            }
        }



        private void txtAJUSTE_Leave(object sender, EventArgs e)
        {
            COMPRA.AJUSTE = (decimal)0.00;
            decimal valor;
            if (Decimal.TryParse(txtAJUSTE.Text, System.Globalization.NumberStyles.Currency, null, out valor))
            {
                COMPRA.AJUSTE = Decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                MessageBox.Show("FORMATO INVALIDO", "ERROR DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtAJUSTE.Text = COMPRA.AJUSTE.ToString("C2");
            calcularTotales();
        }





        private bool validarCompra()
        {
            bool OK = true;
            try
            {
                if (COMPRA.COD_PROVEEDOR == null || COMPRA.COD_PROVEEDOR == string.Empty)
                {
                    OK = false;
                    MessageBox.Show("Seleccione Proveedor para la transaccion", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
                else if (COMPRA.COD_SUC == null || COMPRA.COD_SUC == string.Empty)
                {
                    OK = false;
                    MessageBox.Show("ELIJA SUCURSAL", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
                else if (COMPRA.DOCUMENTO == null || COMPRA.DOCUMENTO == string.Empty)
                {
                    OK = false;
                    MessageBox.Show("DOCUMENTO DE COMPRA INVALIDO", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
                else if (COMPRA.TOTAL <= 0)
                {
                    OK = false;
                    MessageBox.Show("TOTAL DE COMPRA INVALIDO", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
                OK = validarItemsCompra();
            }
            catch (Exception ex)
            {
                OK = false;
                MessageBox.Show("ERROR AL VALIDAR COMPRA", "ERROR VALIDAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return OK;
        }




        private bool validarItemsCompra()
        {
            bool OK = true;
            if (tblITEMS_CALZADO.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tblITEMS_CALZADO.Rows)
                {
                    if (row.Cells["UNIDADES"].Value == null || (Int64)row.Cells["UNIDADES"].Value <= 0)
                    {
                        OK = false;
                        tblITEMS_CALZADO.CurrentRow.Selected = false;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        MessageBox.Show("CANTIDAD INVALIDA EN DETALLE DE COMPRA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["ESTILO"].Value == null || row.Cells["ESTILO"].Value == string.Empty)
                    {
                        OK = false;
                        tblITEMS_CALZADO.CurrentRow.Selected = false;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        MessageBox.Show("PRODUCTO NO ESPECIFICADO EN DETALLE DE COMPRA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["COLOR"].Value == null || row.Cells["COLOR"].Value == string.Empty)
                    {
                        OK = false;
                        tblITEMS_CALZADO.CurrentRow.Selected = false;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        MessageBox.Show("COLOR VACIO EN DETALLE DE COMPRA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    if (row.Cells["MONTO"].Value == null || Decimal.Parse(row.Cells["MONTO"].FormattedValue.ToString(), System.Globalization.NumberStyles.Currency) <= 0)
                    {
                        OK = false;
                        tblITEMS_CALZADO.CurrentRow.Selected = false;
                        tblITEMS_CALZADO.Rows[row.Index].Selected = true;
                        MessageBox.Show("MONTO INVALIDO EN DETALLE DE COMPRA", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            else
            {
                OK = false;
                MessageBox.Show("DETALLE DE COMPRA VACIO", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return OK;
        }







        private void GUARDAR(object sender, EventArgs e)
        {
            txtTOTAL.Focus();
            COMPRA.FECHA = dateCompra.Value;
            COMPRA.DOCUMENTO = txtDOCUMENTO.Text.Trim();
            COMPRA.NOTA = txtNOTA.Text;
            if (validarCompra())
            {
                ConfirmarCompra confirmar = new ConfirmarCompra(COMPRA, ACCION);
                confirmar.ShowDialog();
            }

        }


        private void CANCELAR(object sender, EventArgs e)
        {
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    NUEVO(null, null);
                    break;
                case eOperacion.UPDATE:
                    dbInventario.limpiarPREINGRESO(ACCION, HOME.Instance().USUARIO.COD_EMPLEADO);
                    ACCION = eOperacion.SEARCH;
                    COMPRA = SELECTED.Copy();
                    cargarDatosProveedor(null);
                    cargarDatosCompra();
                    bloquear();

                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLog.Enabled = true;
                    break;
            }
        }



        private void EDITAR(object sender, EventArgs e)
        {
            if (COMPRA != null)
            {
                ACCION = eOperacion.UPDATE;
                dbInventario.setPREINGRESO(COMPRA, HOME.Instance().USUARIO.COD_EMPLEADO);
                cargarPreingreso();
                desbloquear();

                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnLog.Enabled = false;
            }
            else
            {
                MessageBox.Show("COMPRA NO CARGADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void ELIMINAR(object sender, EventArgs e)
        {
            if (COMPRA != null)
            {
                ACCION = eOperacion.DELETE;
                DialogResult eliminar = MessageBox.Show("¿Está seguro que desea eliminar la COMPRA " + COMPRA.DOCUMENTO + " con FECHA:" + COMPRA.FECHA.Date.ToString("dd/MM/yyyy") + " ?", "ELIMINAR COMPRA REGISTRADA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eliminar == DialogResult.Yes)
                {
                    string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                    if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                    {
                        if (dbCompra.delete(COMPRA, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            NUEVO(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                MessageBox.Show("COMPRA NO CARGADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }






        private void BUSCAR(object sender, EventArgs e)
        {
            string numCONT = Controles.InputBox("COMPRA #: ", "BUSCAR");
            if (numCONT != "")
            {
                if (buscarCompra(numCONT))
                {
                    MessageBox.Show("COMPRA # " + COMPRA.DOCUMENTO + " CARGADA", "ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("COMPRA NO ENCONTRADA", "NO ENCONTRADA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }



        public bool buscarCompra(string documento)
        {
            bool OK = false;
            SELECTED = Compra.ConvertToCompra(dbCompra.getCompraByDoc(documento));
            if (SELECTED != null)
            {
                ACCION = eOperacion.SEARCH;
                SELECTED.ITEMS_COMPRA = dbCompra.getItemsCompra(SELECTED);
                COMPRA = SELECTED.Copy();
                cargarDatosProveedor(null);
                cargarDatosCompra();
                calcularTotales();
                bloquear();
                OK = true;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnLog.Enabled = true;
            }
            else
            {
                OK = false;
            }
            return OK;
        }





        private void LOG(object sender, EventArgs e)
        {

        }

        private void AYUDA(object sender, EventArgs e)
        {

        }

        private void ANULAR(object sender, EventArgs e)
        {

        }

       

        

        






    }
}
