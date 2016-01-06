using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ControlesPersonalizados;

namespace KAROL.Catalogos
{
    using DDB;
    using MODELO;

    public partial class ProveedoresForm : Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static ProveedoresForm frmInstance = null;
        private string formName;

        public static ProveedoresForm Instance(string form)
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ProveedoresForm();
            }
            frmInstance.formName = form;
            frmInstance.BringToFront();
            return frmInstance;
        }


        public static ProveedoresForm Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ProveedoresForm();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        //VARIABLES
        private DBKAROL dbKAROL;
        private DBProveedor dbProveedor;

        public DataTable CARTERA;
        private Proveedor SELECTED;

        private eOperacion ACCION;

        public ProveedoresForm()
        {
            InitializeComponent();
            dbProveedor = new DBProveedor();
            dbKAROL = new DBKAROL();
        }



        private void permisos()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnBuscar.Visible = false;
            btnLog.Visible = false;

            foreach(DataRow p in HOME.Instance().USUARIO.PERMISOS.Rows)
            {
                if (p.Field<string>("CODIGO") == "P2")
                {
                    btnNuevo.Visible = p.Field<bool>("REGISTRAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnEliminar.Visible = p.Field<bool>("ELIMINAR");
                    btnBuscar.Visible = p.Field<bool>("BUSCAR");
                    btnLog.Visible = p.Field<bool>("LOG");
                }
            }
        }


        private void ProveedoresForm_Load(object sender, EventArgs e)
        {
            permisos();
            tblPROVEEDORES.AutoGenerateColumns = false;
            ACCION = eOperacion.INSERT;
            cargarDatos();
            bloquear();

        }


        private void bloquear()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLog.Enabled = false;
        }



        public void cargarDatos()
        {
            CARTERA = dbProveedor.showProveedores();
            tblPROVEEDORES.DataSource = CARTERA.Copy();
            bloquear();
        }






        private void cargarSelected(){
            SELECTED = new Proveedor();
            if (tblPROVEEDORES.CurrentCell != null )
            {
                SELECTED = Proveedor.ConvertToProveedor(CARTERA.Rows[tblPROVEEDORES.CurrentCell.RowIndex]);
                
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnLog.Enabled = true;
            }
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            ACCION = eOperacion.INSERT;
            RegistrarProveedorForm nuevo = new RegistrarProveedorForm();
            nuevo.ShowDialog(this);
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tblPROVEEDORES.SelectedRows.Count == 1)
            {
                ACCION = eOperacion.UPDATE;
                cargarSelected();
                RegistrarProveedorForm nuevo = new RegistrarProveedorForm(SELECTED);
                nuevo.ShowDialog(this);
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblPROVEEDORES.SelectedRows.Count == 1)
            {
                DialogResult eliminar = MessageBox.Show("¿Está seguro que desea eliminar al proveedor " + SELECTED.NOMBRE + " de la Cartera ?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eliminar == DialogResult.Yes)
                {
                    string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                    if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                    {
                        ACCION = eOperacion.DELETE;
                        cargarSelected();
                        string codigo = SELECTED.COD_PROVEEDOR;
                        if (dbProveedor.delete(codigo, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            cargarDatos();
                        }
                     }
                     else
                     {
                         MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                     }
                }
            }
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            ACCION = eOperacion.SEARCH;
            BuscarProveedor nuevo = new BuscarProveedor();
            nuevo.ShowDialog(this);
        }




     


        private void tblPROVEEDORES_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblPROVEEDORES.CurrentCell != null && tblPROVEEDORES.CurrentCell.RowIndex >= 0)
            {
                cargarSelected();
            }
        }






        private void tblPROVEEDORES_DataSourceChanged(object sender, EventArgs e)
        {
            if (tblPROVEEDORES.DataSource != null)
            {
                lbNUM.Text = tblPROVEEDORES.Rows.Count.ToString();
            }
        }



        private void tblPROVEEDORES_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblPROVEEDORES.CurrentCell != null && tblPROVEEDORES.CurrentCell.RowIndex >= 0 && tblPROVEEDORES.SelectedRows.Count == 1)
            {
                cargarSelected();
                switch (formName)
                {
                    case "ComprasForm":
                        Transacciones.ComprasForm.Instance().cargarDatosProveedor(SELECTED);
                        this.Close();
                        break;
                    case "ContratosForm":
                        //Movimientos.ContratosForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                    case "VentasForm":
                        //Movimientos.VentasForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                    case "REstadoCuentaForm":
                        //Reportes.REstadoCuentaForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                }
            }
        }




        private void btnLog_Click(object sender, EventArgs e)
        {
            if (tblPROVEEDORES.SelectedRows.Count == 1)
            {
                cargarSelected();
                string codigo = SELECTED.COD_PROVEEDOR;
                //DataTable log = dbPrendasal.GET_LOG_CLIENTE(SELECTED.CODIGO , HOME.Instance().SISTEMA);
                //if (log.Rows.Count > 0)
                //{
                //    Controles.ShowLogDialog("LOG CLIENTE :" + SELECTED.CODIGO, log);
                //}
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (CARTERA != null)
            {
                HOME.Instance().exportDataGridViewToExcel("PROVEEDORES", tblPROVEEDORES.Columns, CARTERA, "Proveedores");
            }
        }



    }
}
