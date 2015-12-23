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
        private DBCompra dbCompra;

        private eOperacion ACCION;

        private Compra COMPRA;
        private Compra SELECTED;

        public ComprasForm()
        {
            InitializeComponent();
            this.tblITEMS_CALZADO.InitColumnTable();
            dbKAROL = new DBKAROL();
            dbProveedor = new DBProveedor();
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
            btnReimprimir.Visible = false;

            foreach (DataRow p in HOME.Instance().USUARIO.PERMISOS.Rows)
            {
                if (p.Field<string>("CODIGO") == "P7")
                {
                    btnNuevo.Visible = p.Field<bool>("REGISTRAR");
                    btnGuardar.Visible = p.Field<bool>("REGISTRAR") || p.Field<bool>("ACTUALIZAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnAnular.Visible = p.Field<bool>("ANULAR");
                    btnEliminar.Visible = p.Field<bool>("ELIMINAR");
                    btnBuscar.Visible = p.Field<bool>("BUSCAR");
                    btnLog.Visible = p.Field<bool>("LOG");
                    btnReimprimir.Visible = p.Field<bool>("REIMPRIMIR");
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
            tblITEMS_CALZADO.ReadOnly = true;
            txtAJUSTE.ReadOnly = true;
        }


        private void desbloquear()
        {
            grbCOMPRA.Enabled = true;
            tabDETALLE.Enabled = true;
            tblITEMS_CALZADO.ReadOnly = false;
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




        private void NUEVO(object sender, EventArgs e)
        {
            ACCION = eOperacion.INSERT;
            COMPRA = new Compra();
            COMPRA.COD_SUC = HOME.Instance().SUCURSAL.COD_SUC;
            COMPRA.FECHA = HOME.Instance().FECHA_SISTEMA;
            COMPRA.TIPO = eTipoCompra.IMPORTADO;
            COMPRA.TIPO_PAGO = eTipoPago.EFECTIVO;
            cargarDatosProveedor(null);
            cargarDatosCompra();
            desbloquear();
            txtDOCUMENTO.Focus();

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLog.Enabled = false;
            btnReimprimir.Enabled = false;

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
            COMPRA.TOTAL = COMPRA.ITEMS_COMPRA.AsEnumerable().Select(r => r.Field<decimal>("MONTO")).Sum();
            txtTOTAL.Text = COMPRA.TOTAL.ToString("C2");
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
                    MessageBox.Show("Seleccione Sucursal", "VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
                else if (COMPRA.DOCUMENTO == string.Empty)
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






        private void btnAddItem_Click(object sender, EventArgs e)
        {
            switch (tabDETALLE.SelectedTab.Name)
            {
                case "pagCALZADO":
                    IngresoDetalleForm nuevo = new IngresoDetalleForm(eCategoria.CALZADO);
                    nuevo.ShowDialog(this);
                    break;
                case "pagCARTERA":
                    break;
                case "pagROPA":
                    break;
                case "pagMOCHILA":
                    break;

            }
        }

        public void AgregarItem(eCategoria categoria,string estilo,eCorridaCalzado curva, DataTable ITEMS,decimal monto){
            foreach (DataRow row in ITEMS.Rows)
                {
                    int totalItem = 0;
                    decimal montoItem = (decimal)0.00;
                    totalItem = totalItem + row.Field<int>("T1") + row.Field<int>("T2") + row.Field<int>("T3") + row.Field<int>("T4") +
                        row.Field<int>("T5") + row.Field<int>("T6") + row.Field<int>("T7") + row.Field<int>("T8") + row.Field<int>("T9") + row.Field<int>("T10") + row.Field<int>("T11") + row.Field<int>("T12") + row.Field<int>("T13");
                    if (totalItem != 0)
                    {
                        montoItem = Decimal.Round(monto / totalItem,2,MidpointRounding.AwayFromZero);
                    }

                    COMPRA.ITEMS_COMPRA.Rows.Add("CODIGO X", categoria.ToString(), estilo, row.Field<string>("COLOR"), curva.ToString(), row.Field<int>("T1"), row.Field<int>("T2"), row.Field<int>("T3"), row.Field<int>("T4"), row.Field<int>("T5"),
                        row.Field<int>("T6"), row.Field<int>("T7"), row.Field<int>("T8"), row.Field<int>("T9"), row.Field<int>("T10"), row.Field<int>("T11"), row.Field<int>("T12"), row.Field<int>("T13"),montoItem);
                }
        }

        






    }
}
