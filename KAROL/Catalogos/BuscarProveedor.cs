using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAROL.Catalogos
{
    using DDB;
    using MODELO;

    public partial class BuscarProveedor : Form
    {
        private DBProveedor dbProveedor;
        private DataTable FILTRO;


        public BuscarProveedor()
        {
            InitializeComponent();
            dbProveedor = new DBProveedor();
            rdbDOC.Checked = true;
            cbmTIPODOC.DataSource = Enum.GetValues(new eTipoDoc().GetType());
        }


        private void rdbCODIGO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCODIGO.Checked)
            {
                txtCODIGO.Text = "";
                txtCODIGO.Enabled = true;
                txtNOMBRE.Enabled = false;
                cbmTIPODOC.Enabled = false;
                txtDOC.Enabled = false;
            }
        }

        private void rdbNOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNOMBRE.Checked)
            {
                txtNOMBRE.Text = "";
                txtNOMBRE.Enabled = true;
                txtCODIGO.Enabled = false;
                cbmTIPODOC.Enabled = false;
                txtDOC.Enabled = false;
            }
            
        }

        private void rdbDOC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDOC.Checked)
            {
                txtDOC.Text = "";
                cbmTIPODOC.Enabled = true;
                txtDOC.Enabled = true;
                txtCODIGO.Enabled = false;
                txtNOMBRE.Enabled = false;
            }
            
        }

        private bool validar()
        {
            bool OK = true;
            if (rdbCODIGO.Checked && txtCODIGO.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("CODIGO VACIO", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdbNOMBRE.Checked && txtNOMBRE.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("NOMBRE VACIO", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdbDOC.Checked && txtDOC.Text.Trim() == string.Empty)
            {
                OK = false;
                MessageBox.Show("DOCUMENTO VACIO", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return OK;
        }





        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (rdbCODIGO.Checked)
                {
                    FILTRO = dbProveedor.findByCodigoLIKE(txtCODIGO.Text);
                }
                else if (rdbNOMBRE.Checked)
                {
                    FILTRO = dbProveedor.findByNombreLIKE(txtNOMBRE.Text);
                }
                else if (rdbDOC.Checked)
                {
                    switch((eTipoDoc) cbmTIPODOC.SelectedItem){
                        case eTipoDoc.DUI:
                            FILTRO = dbProveedor.findByDuiLIKE(txtDOC.Text);
                            break;
                        case eTipoDoc.NIT:
                            FILTRO = dbProveedor.findByNitLIKE(txtDOC.Text);
                            break;
                        case eTipoDoc.NRC:
                            FILTRO = dbProveedor.findByNrcLIKE(txtDOC.Text);
                            break;
                    }
                }
                ProveedoresForm.Instance().CARTERA = FILTRO;
                ProveedoresForm.Instance().cargarDatos();
                this.Close();
            }
        }






        private void txtCODIGO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        


        private void txtNOMBRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        



        private void txtDOC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }
    }
}
