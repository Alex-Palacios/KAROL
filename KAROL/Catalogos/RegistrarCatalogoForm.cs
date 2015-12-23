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

    public partial class RegistrarCatalogoForm : Form
    {
        //VARIABLES
        private DBUsuario dbUser;
        private DBCatalogo dbCatalogo;
        private DBKAROL dbKAROL;

        private Catalogo SELECTED;
        private eOperacion ACCION;

        public RegistrarCatalogoForm()
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbUser = new DBUsuario();
            dbCatalogo = new DBCatalogo();

            ACCION = eOperacion.INSERT;
        }

        public RegistrarCatalogoForm(Catalogo item)
        {
            InitializeComponent();
            dbKAROL = new DBKAROL();
            dbUser = new DBUsuario();
            dbCatalogo = new DBCatalogo();

            ACCION = eOperacion.UPDATE;
            SELECTED = item;
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
            cbxCATEGORIA.DataSource = Enum.GetValues(new eCategoria().GetType());
            cbxUM.DataSource = Enum.GetValues(new eUnidadMedida().GetType());
            
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    break;
                case eOperacion.UPDATE:
                    txtCODIGO.ReadOnly = true;
                    cargarITEM();
                    break;
            }
        }



        private bool validar()
        {
            bool OK = true;
            if (txtCODIGO.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Estilo Requerido", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return OK;
            }
            if (txtMARCA.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("Marca Requerida","ERROR DE VALIDACION DE DATOS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return OK;
            }
            
            return OK;
        }




        public Catalogo buildITEM()
        {
            Catalogo c = new Catalogo();
            c.CATEGORIA = (eCategoria)cbxCATEGORIA.SelectedItem;
            c.COD_ITEM = txtCODIGO.Text.Trim().ToUpper();
            c.MARCA = txtMARCA.Text.Trim();
            c.DESCRIPCION = txtDESCRIPCION.Text;
            c.UNIDAD_MEDIDA = (eUnidadMedida)cbxUM.SelectedItem;
            return c;
        }



        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void GUARDAR_Click(object sender, EventArgs e)
        {
            Catalogo c = new Catalogo();
            switch (ACCION)
            {
                case eOperacion.INSERT:
                    if (validar())
                    {
                        c = buildITEM();
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbCatalogo.insert(c, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                CatalogoForm.Instance().cargarDatos();
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
                        c = buildITEM();
                        c.COD_ITEM = SELECTED.COD_ITEM;
                        string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                        if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                        {
                            if (dbCatalogo.update(c, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                            {
                                CatalogoForm.Instance().cargarDatos();
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




        private void cargarITEM()
        {
            if (SELECTED != null)
            {
                cbxCATEGORIA.SelectedItem = SELECTED.CATEGORIA;
                txtCODIGO.Text = SELECTED.COD_ITEM;
                txtMARCA.Text = SELECTED.MARCA;
                txtDESCRIPCION.Text = SELECTED.DESCRIPCION;
                cbxUM.SelectedItem = SELECTED.UNIDAD_MEDIDA;
            }
        }








    }
}
