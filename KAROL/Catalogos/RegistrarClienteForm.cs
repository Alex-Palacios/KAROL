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

    public partial class RegistrarClienteForm : Form
    {
        //VARIABLES
        private DBUsuario dbUser;
        private DBCliente dbCliente;
        private DBSucursal dbSucursal;
        private DBKAROL dbKAROL;

        private Cliente SELECTED;
        private eOperacion ACCION;

        public RegistrarClienteForm()
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbSucursal = new DBSucursal();
            dbUser = new DBUsuario();
            dbCliente = new DBCliente();

            ACCION = eOperacion.INSERT;
            btnSCANDOC.Enabled = false;
        }

        public RegistrarClienteForm(Cliente cliente)
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbSucursal = new DBSucursal();
            dbUser = new DBUsuario();
            dbCliente = new DBCliente();

            ACCION = eOperacion.UPDATE;
            SELECTED = cliente;
            btnSCANDOC.Enabled = true;
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
            DataTable deptos = dbKAROL.getDeptos();
            if (deptos.Rows.Count > 0)
            {
                DataRow rowD = deptos.NewRow();
                rowD.SetField<string>("DEPTO", "Seleccione Depto");
                deptos.Rows.InsertAt(rowD, 0);
            }
            else
            {
                deptos.Columns.Add("DEPTO");
                deptos.Rows.Add("Seleccione Depto");
            }
            cbxDEPTO.DataSource = deptos;
            if (deptos.Rows.Count > 0)
            {
                cbxDEPTO.DisplayMember = "DEPTO";
                cbxDEPTO.SelectedIndex = 0;
            }
            DataTable MUNI = dbKAROL.getMunicipios(null);
            if (MUNI.Rows.Count > 0)
            {
                DataRow rowM = MUNI.NewRow();
                rowM.SetField<string>("COD_MUNICIPIO", "XXXX");
                rowM.SetField<string>("MUNICIPIO", "-------");
                MUNI.Rows.InsertAt(rowM, 0);
            }

            cbxEXT.DataSource = MUNI;
            if (MUNI.Rows.Count > 0)
            {
                cbxEXT.DisplayMember = "MUNICIPIO";
                cbxEXT.ValueMember = "COD_MUNICIPIO";
                cbxEXT.SelectedIndex = 0;
            }
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    txtCODIGO.Text = "N/A";
                    dateINICIO.Value = HOME.Instance().FECHA_SISTEMA;
                    dateNAC.Value = HOME.Instance().FECHA_SISTEMA.AddYears(-18);
                    break;
                case eOperacion.UPDATE:
                    cargarCLIENTE();
                    break;
            }
        }



        private bool validar()
        {
            bool OK = true;
            
            if (txtNOMBRE.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese nombre del cliente","ERROR DE VALIDACION DE DATOS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return OK;
            }
            if(dateNAC.Value != null){
                int edad = DateTime.Today.AddTicks(-dateNAC.Value.Date.Ticks).Year - 1;
                if (edad < 18)
                {
                    OK = false;
                    MessageBox.Show("Cliente debe ser mayor de edad", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return OK;
                }
            }
            if (txtDUI.Text.Trim() == string.Empty && txtNIT.Text.Trim() == string.Empty && txtNRC.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese al menos un documento de identificacion del cliente", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (ckM.Checked && ckF.Checked)
            {
                OK = false;
                MessageBox.Show("Especifique sexo del cliente", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtDUI.Text.Trim() != string.Empty && cbxEXT.SelectedIndex == 0)
            {
                OK = false;
                MessageBox.Show("Indique lugar de extension del documento", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtTELEFONO.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Telefono del cliente requerido", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtPROFESION.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Especifique Profesion del cliente", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (cbxDEPTO.SelectedIndex == 0 || cbxMUNICIPIO.SelectedIndex == 0)
            {
                OK = false;
                MessageBox.Show("Especifique domicilio actual del cliente", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtDIRECCION.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Ingrese direccion actual del cliente", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        public Cliente buildCLIENTE()
        {
            Cliente c = new Cliente();
            c.FECHA_INICIO = dateINICIO.Value;
            c.NATURALEZA = (eNaturalezaPersona)cbxNATURALEZA.SelectedItem;
            c.NOMBRE = txtNOMBRE.Text;
            if (ckF.Checked) { c.SEXO = eSexo.FEMENINO; }
            else if (ckM.Checked) { c.SEXO = eSexo.MASCULINO; }
            c.FECHA_NAC = dateNAC.Value.Date;
            c.DUI = txtDUI.Text.Trim();
            if (cbxEXT.SelectedIndex > 0)
            {
                c.EXT = (string)cbxEXT.SelectedValue;
            }
            c.FECHA_VENC = dateFechaVenc.Value;
            c.NIT = txtNIT.Text.Trim();
            c.NRC = txtNRC.Text.Trim();
            c.TEL = txtTELEFONO.Text;
            c.EMAIL = txtEMAIL.Text;
            c.PROFESION = txtPROFESION.Text;
            if (cbxMUNICIPIO.SelectedIndex > 0)
            {
                c.COD_MUNICIPIO = (string)cbxMUNICIPIO.SelectedValue;
            }
            c.DIRECCION = txtDIRECCION.Text;
            c.DIRECCION_OPCIONAL = txtDirecOPCIONAL.Text;
            c.NEGOCIO = txtNEGOCIO.Text;
            c.TEL_NEGOCIO = txtTELNEG.Text;
            c.DIRECCION_NEGOCIO = txtDirecNEG.Text;
            c.NOTA = txtNOTA.Text;
            return c;
        }



        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void GUARDAR_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    if (validar())
                    {
                        c = buildCLIENTE();
                        c.LIMITE_CREDITO = (decimal)0.00;
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbCliente.insert(c, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                ClientesForm.Instance().cargarDatos();
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
                        c = buildCLIENTE();
                        c.COD_CLIENTE = SELECTED.COD_CLIENTE;
                        c.LIMITE_CREDITO = SELECTED.LIMITE_CREDITO;
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbCliente.update(c, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                ClientesForm.Instance().cargarDatos();
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




        private void cargarCLIENTE()
        {
            if (SELECTED != null)
            {
                txtCODIGO.Text = SELECTED.COD_CLIENTE;
                dateINICIO.Value = SELECTED.FECHA_INICIO;
                cbxNATURALEZA.SelectedItem = SELECTED.NATURALEZA;
                txtNOMBRE.Text = SELECTED.NOMBRE;
                if (SELECTED.SEXO == null || SELECTED.SEXO == eSexo.MASCULINO)
                {
                    ckM.Checked = true;
                }
                else if (SELECTED.SEXO == eSexo.FEMENINO)
                {
                    ckF.Checked = true;
                }
                if (SELECTED.FECHA_NAC != null)
                {
                    dateNAC.Value = SELECTED.FECHA_NAC.Value;
                }
                else
                {
                    dateNAC.Value = HOME.Instance().FECHA_SISTEMA.AddYears(-18);
                }
                txtDUI.Text = SELECTED.DUI;
                if (SELECTED.EXT != null && SELECTED.EXT != string.Empty)
                {
                    cbxEXT.SelectedValue = SELECTED.EXT;
                }
                else
                {
                    cbxEXT.SelectedIndex = 0;
                }
                if (SELECTED.FECHA_VENC != null)
                {
                    dateFechaVenc.Value = SELECTED.FECHA_VENC.Value;
                }
                else
                {
                    dateFechaVenc.Value = HOME.Instance().FECHA_SISTEMA;
                }
                txtNIT.Text = SELECTED.NIT;
                txtNRC.Text = SELECTED.NRC;
                txtPROFESION.Text = SELECTED.PROFESION;
                if (SELECTED.COD_MUNICIPIO != null)
                {
                    cbxDEPTO.Text = SELECTED.DEPTO;
                    cbxMUNICIPIO.SelectedValue = SELECTED.COD_MUNICIPIO;
                }
                else
                {
                    cbxDEPTO.SelectedIndex = 0;
                }
                txtDIRECCION.Text = SELECTED.DIRECCION;

                txtTELEFONO.Text = SELECTED.TEL;
                txtDirecOPCIONAL.Text = SELECTED.DIRECCION_OPCIONAL;
                txtEMAIL.Text = SELECTED.EMAIL;
                txtNEGOCIO.Text = SELECTED.NEGOCIO;
                txtTELNEG.Text = SELECTED.TEL_NEGOCIO;
                txtDirecNEG.Text = SELECTED.DIRECCION_NEGOCIO;
                txtNOTA.Text = SELECTED.NOTA;
            }
        }




        private void cbmDEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDEPTO.SelectedIndex > 0)
            {
                DataTable MUNI = dbKAROL.getMunicipios(cbxDEPTO.Text);
                cbxMUNICIPIO.DataSource = MUNI;
                if (MUNI.Rows.Count > 0)
                {
                    DataRow rowM = MUNI.NewRow();
                    rowM.SetField<string>("COD_MUNICIPIO", "XXXX");
                    rowM.SetField<string>("MUNICIPIO", "-------");
                    MUNI.Rows.InsertAt(rowM, 0);
                    cbxMUNICIPIO.ValueMember = "COD_MUNICIPIO";
                }
                cbxMUNICIPIO.DisplayMember = "MUNICIPIO";
                cbxMUNICIPIO.SelectedIndex = 0;
            }
            else
            {
                cbxMUNICIPIO.DataSource = null;
            }
        }






    }
}
