using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAROL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool activo;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "SplashScreen",
                                       out activo);

            if (!activo)
            {
                MessageBox.Show("La aplicacion ya esta ejecutandose");
                Application.Exit();
            }
            else
            {
                try
                {
                    //Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SplashScreen());
                }
                catch (Exception ex)
                {
                    DialogResult cerrar = MessageBox.Show("ERROR NO CONTROLADO POR LA APP ...\nDetalle Error: \n " + ex.Message + "\nDESEA REINICIAR LA APLICACION?", "ERROR INESPERADO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (cerrar == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                        Application.ExitThread();
                    }
                }
            }
            //Liberamos la exclusión mutua
            m.ReleaseMutex();
        }
    }
}
