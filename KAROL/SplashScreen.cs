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
    using System.Threading;
    using System.Net.NetworkInformation;
    using MODELO;

    public partial class SplashScreen : Form
    {
        //VARIABLES
        public bool OK;

        public SplashScreen()
        {
            OK = true;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            background.Dispose(); 
            background.RunWorkerAsync();
            
        }


        private void tareaBackground(object sender, DoWorkEventArgs e)
        {
            verificarConexionServer();
            background.ReportProgress(30);
            verificarConexionBD();
            background.ReportProgress(50);
            background.ReportProgress(60);
            background.ReportProgress(70);
            background.ReportProgress(90);
            background.ReportProgress(100);
        }

        private void progresoTarea(object sender, ProgressChangedEventArgs e)
        {
            progreso.Value = e.ProgressPercentage;
            if (progreso.Value == 70)
            {
                progressText.Text = "Iniciando componentes ... OK";
            }
            else if (progreso.Value == 90)
            {
                progressText.Text = "Cargando GUI ... OK";
            }
            else if (progreso.Value == 100)
            {
                progressText.Text = "INICIANDO ...";
            }
        }



        private void tareaCompletada(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Inicio Cancelado");
                Application.Exit();
            }
            else
            {
                if (OK)
                {
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult reiniciar = MessageBox.Show("CONEXION A BD FALLO DESEA REINICIAR APLICACION?", "ERROR INESPERADO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (reiniciar == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }



        // TAREAS

        public void verificarConexionServer()
        {
            progressText.Text = "Verificando conexion con servidor ..." + Properties.Settings.Default.SISTEMA;
            try
            {
                Ping Pings = new Ping();
                int timeout = 5000;
                if (Pings.Send(Properties.Settings.Default.SISTEMA, timeout).Status == IPStatus.Success)
                {
                    progressText.Text = "Conexion con servidor exitosa a ... " + Properties.Settings.Default.SISTEMA;
                    Thread.Sleep(1000);
                }
                else
                {
                    progressText.Text = "Fallo conexion con servidor ...  " + Properties.Settings.Default.SISTEMA;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                progressText.Text = "Error al verificar conexion con servidor ";
            }

        }




        public void verificarConexionBD()
        {
            progressText.Text = "Verificando conexion con Base de Datos ...";
            try
            {
                //seteando parametros de conexion
                DDB.DBConexion conn = new DDB.DBConexion(Properties.Settings.Default.DRIVER, Properties.Settings.Default.SERVER, Properties.Settings.Default.PUERTO, Properties.Settings.Default.DATABASE, Properties.Settings.Default.USERDB, Properties.Settings.Default.PASSWORD);
                progressText.Text = "Conexion con Base de Datos :" + conn.conection.State;
                if (conn.conection.State != ConnectionState.Open)
                {
                    OK = false;
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                progressText.Text = "Fallo conexion con Base de Datos";
                OK = false;
                Thread.Sleep(1000);
            }
        }



    }
}
