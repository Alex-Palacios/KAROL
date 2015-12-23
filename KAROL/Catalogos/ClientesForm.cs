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

    public partial class ClientesForm : Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static ClientesForm frmInstance = null;
        private string formName;

        public static ClientesForm Instance(string form)
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ClientesForm();
            }
            frmInstance.formName = form;
            frmInstance.BringToFront();
            return frmInstance;
        }


        public static ClientesForm Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new ClientesForm();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        //VARIABLES
        private DBKAROL dbKAROL;
        private DBCliente dbCliente;

        public DataTable CARTERA;
        private Cliente SELECTED;

        private eOperacion ACCION;

        public ClientesForm()
        {
            InitializeComponent();
            dbCliente = new DBCliente();
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
                if (p.Field<string>("CODIGO") == "P1")
                {
                    btnNuevo.Visible = p.Field<bool>("REGISTRAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnEliminar.Visible = p.Field<bool>("ELIMINAR");
                    btnBuscar.Visible = p.Field<bool>("BUSCAR");
                    btnLog.Visible = p.Field<bool>("LOG");
                }
            }
        }


        private void ClientesForm_Load(object sender, EventArgs e)
        {
            permisos();
            tblCLIENTES.AutoGenerateColumns = false;
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
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    CARTERA = dbCliente.findByFechaInicio(HOME.Instance().FECHA_SISTEMA);
                    tblCLIENTES.DataSource = CARTERA.Copy();
                    break;
                case eOperacion.UPDATE:
                    CARTERA = dbCliente.findByFechaInicio(HOME.Instance().FECHA_SISTEMA);
                    tblCLIENTES.DataSource = CARTERA.Copy();
                    break;
                case eOperacion.DELETE:
                    CARTERA = dbCliente.findByFechaInicio(HOME.Instance().FECHA_SISTEMA);
                    tblCLIENTES.DataSource = CARTERA.Copy();
                    break;
                case eOperacion.SEARCH:
                    tblCLIENTES.DataSource = CARTERA.Copy();
                    break;
            }
            bloquear();
        }






        private void cargarSelected(){
            SELECTED = new Cliente();
            if (tblCLIENTES.CurrentCell != null )
            {
                SELECTED = Cliente.ConvertToCliente(CARTERA.Rows[tblCLIENTES.CurrentCell.RowIndex]);
                
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnLog.Enabled = true;
            }
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            ACCION = eOperacion.INSERT;
            RegistrarClienteForm nuevo = new RegistrarClienteForm();
            nuevo.ShowDialog(this);
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tblCLIENTES.SelectedRows.Count == 1)
            {
                ACCION = eOperacion.UPDATE;
                cargarSelected();
                RegistrarClienteForm nuevo = new RegistrarClienteForm(SELECTED);
                nuevo.ShowDialog(this);
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblCLIENTES.SelectedRows.Count == 1)
            {
                DialogResult eliminar = MessageBox.Show("¿Está seguro que desea eliminar al cliente " + SELECTED.NOMBRE + " de la Cartera ?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eliminar == DialogResult.Yes)
                {
                    string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                    if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                    {
                        ACCION = eOperacion.DELETE;
                        cargarSelected();
                        string codigo = SELECTED.COD_CLIENTE;
                        if (dbCliente.delete(codigo, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
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
            BuscarCliente nuevo = new BuscarCliente();
            nuevo.ShowDialog(this);
        }




     


        private void tblCLIENTES_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCLIENTES.CurrentCell != null && tblCLIENTES.CurrentCell.RowIndex >= 0)
            {
                cargarSelected();
            }
        }






        private void tblCLIENTES_DataSourceChanged(object sender, EventArgs e)
        {
            if (tblCLIENTES.DataSource != null)
            {
                lbNUM.Text = tblCLIENTES.Rows.Count.ToString();
            }
        }



        private void tblCLIENTES_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCLIENTES.CurrentCell != null && tblCLIENTES.CurrentCell.RowIndex >= 0 && tblCLIENTES.SelectedRows.Count == 1)
            {
                cargarSelected();
                switch (formName)
                {
                    case "ComprasForm":
                        //Movimientos.ComprasForm.Instance().cargarDatosCliente(SELECTED);
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
            if (tblCLIENTES.SelectedRows.Count == 1)
            {
                cargarSelected();
                string codigo = SELECTED.COD_CLIENTE;
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
                HOME.Instance().exportDataGridViewToExcel("CARTERA DE CLIENTES", tblCLIENTES.Columns, CARTERA, "CarteraClientes");
            }
        }



    }
}
