using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAROL
{
    using DevComponents.DotNetBar;

    using DDB;
    using MODELO;

    public partial class LoginForm : Form
    {
        //VARIABLES
        private DBKAROL dbKarol;
        private DBUsuario dbUser;
        private DBSucursal dbSucursal;
        private Sucursal SUC;
        private Usuario USER;
        private DateTime FECHA;

        public LoginForm()
        {
            InitializeComponent();
            dbKarol = new DBKAROL();
            dbUser = new DBUsuario();
            dbSucursal = new DBSucursal();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SUC = Sucursal.ConverterToSucursal(dbSucursal.findByCodigoConfig(Properties.Settings.Default.SUCURSAL));
            if (SUC == null)
            {
                
                Application.Exit();
               
            }
            else
            {
                switch (SUC.FECHA_SISTEMA)
                {
                    case GlobalFechaSistema.SERVIDOR:
                        FECHA = dbKarol.date_system();
                        break;
                    case GlobalFechaSistema.CLIENTE:
                        FECHA = DateTime.Today;
                        break;
                    default:
                        Application.Exit();
                        break;
                }
                dateFECHASYSTEM.Value = FECHA;
            }
            txtUSER.Focus();
        }





        private void btnSALIR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private bool validar()
        {
            bool OK = true;
            txtUSER.Border.BorderColor = Color.Empty;
            txtPASSWORD.Border.BorderColor = Color.Empty;
            if (txtUSER.Text.Trim() == string.Empty)
            {
                OK = false;
                txtUSER.Border.BorderColor = Color.Red;
                MessageBox.Show("Ingrese USERNAME", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPASSWORD.Text.Trim() == string.Empty)
            {
                OK = false;
                txtPASSWORD.Border.BorderColor = Color.Red;
                MessageBox.Show("Ingrese su CONTRASEÑA", "ERROR DE VALIDACION DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return OK;
        }


        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (dbKarol.LOGIN(Properties.Settings.Default.SISTEMA, txtUSER.Text, txtPASSWORD.Text))
                {
                    USER = Usuario.ConvertToUsuario(dbUser.getUser(Properties.Settings.Default.SISTEMA, txtUSER.Text));
                    if (USER != null)
                    {
                        HOME.Instance().OPEN_SESION(USER, SUC, FECHA);
                        this.Close();
                    }
                    else
                    {
                        txtPASSWORD.Text = "";
                    }
                }
                else
                {
                    txtPASSWORD.Text = "";
                }
            }
        }





        private void txtUSER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPASSWORD.Focus();
            }
        }


        private void txtPASSWORD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLOGIN.Focus();
            }
        }





    }
}
