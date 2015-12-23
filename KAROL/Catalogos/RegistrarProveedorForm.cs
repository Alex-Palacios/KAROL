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

namespace KAROL.Catalogos
{
    using MODELO;
    using DDB;

    public partial class RegistrarProveedorForm : Form
    {
        //VARIABLES
        private DBUsuario dbUser;
        private DBProveedor dbProveedor;
        private DBSucursal dbSucursal;
        private DBKAROL dbKAROL;

        private Proveedor SELECTED;
        private eOperacion ACCION;

        public RegistrarProveedorForm()
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbSucursal = new DBSucursal();
            dbUser = new DBUsuario();
            dbProveedor = new DBProveedor();

            ACCION = eOperacion.INSERT;
        }

        public RegistrarProveedorForm(Proveedor proveedor)
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbSucursal = new DBSucursal();
            dbUser = new DBUsuario();
            dbProveedor = new DBProveedor();

            ACCION = eOperacion.UPDATE;
            SELECTED = proveedor;
        }


        private void permisos_FORM()
        {
            switch (HOME.Instance().USUARIO.TIPO)
            {
                case eTipoUsuario.VENDEDOR:
                    
                    break;
                default:
                    
                    break;
            }
        }

        private void RegistrarClienteForm_Load(object sender, EventArgs e)
        {
            permisos_FORM();
            cbxNATURALEZA.DataSource = Enum.GetValues(new eNaturalezaPersona().GetType());
            
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    txtCODIGO.Text = "N/A";
                    dateINICIO.Value = HOME.Instance().FECHA_SISTEMA;
                    break;
                case eOperacion.UPDATE:
                    cargarPROVEEDOR();
                    break;
            }
        }



        private bool validar()
        {
            bool OK = true;
            
            if (txtNOMBRE.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese nombre del proveedor","ERROR DE VALIDACION DE DATOS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return OK;
            }
            if (txtDUI.Text.Trim() == string.Empty && txtNIT.Text.Trim() == string.Empty && txtNRC.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese al menos un documento de identificacion del proveedor", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtTELEFONO.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Telefono del proveedor requerido", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtPAIS.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Especifique Profesion del proveedor", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtDIRECCION.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese direccion actual del proveedor", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtDUI.Text.Trim() != string.Empty && txtDUI.Text.Trim().Length != 10)
            {
                OK = false;
                MessageBox.Show("El DUI debe ser un numero de 10 digitos", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            return OK;
        }




        public Proveedor buildPROVEEDOR()
        {
            Proveedor p = new Proveedor();
            p.FECHA_INICIO = dateINICIO.Value;
            p.NATURALEZA = (eNaturalezaPersona)cbxNATURALEZA.SelectedItem;
            p.NOMBRE = txtNOMBRE.Text;
            p.DUI = txtDUI.Text.Trim();
            p.NIT = txtNIT.Text.Trim();
            p.NRC = txtNRC.Text.Trim();
            p.TEL = txtTELEFONO.Text;
            p.EMAIL = txtEMAIL.Text;
            p.PAIS = txtPAIS.Text;
            p.DIRECCION = txtDIRECCION.Text;
            p.CONTACTO = txtCONTACTO.Text;
            p.TEL_CONTACTO = txtTELCONTACTO.Text;
            p.NOTA = txtNOTA.Text;
            return p;
        }



        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void GUARDAR_Click(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor();
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    if (validar())
                    {
                        p = buildPROVEEDOR();
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbProveedor.insert(p, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                ProveedoresForm.Instance().cargarDatos();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        
                    }
                    break;
                case eOperacion.UPDATE:
                    if (validar())
                    {
                        p = buildPROVEEDOR();
                        p.COD_PROVEEDOR = SELECTED.COD_PROVEEDOR;
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbProveedor.update(p, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                ProveedoresForm.Instance().cargarDatos();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    break;
            }
            
        }




        private void cargarPROVEEDOR()
        {
            if (SELECTED != null)
            {
                txtCODIGO.Text = SELECTED.COD_PROVEEDOR;
                dateINICIO.Value = SELECTED.FECHA_INICIO;
                cbxNATURALEZA.SelectedItem = SELECTED.NATURALEZA;
                txtNOMBRE.Text = SELECTED.NOMBRE;
                txtDUI.Text = SELECTED.DUI;
                txtNIT.Text = SELECTED.NIT;
                txtNRC.Text = SELECTED.NRC;
                txtPAIS.Text = SELECTED.PAIS;
                txtDIRECCION.Text = SELECTED.DIRECCION;

                txtTELEFONO.Text = SELECTED.TEL;
                txtEMAIL.Text = SELECTED.EMAIL;
                txtCONTACTO.Text = SELECTED.CONTACTO;
                txtTELCONTACTO.Text = SELECTED.TEL_CONTACTO;
                txtNOTA.Text = SELECTED.NOTA;
            }
        }








    }
}
